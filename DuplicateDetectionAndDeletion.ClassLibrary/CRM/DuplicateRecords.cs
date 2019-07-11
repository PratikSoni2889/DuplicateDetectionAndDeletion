using DuplicateDetectionAndDeletion.ClassLibrary.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DuplicateDetectionAndDeletion.ClassLibrary.CRM
{
    public static class DuplicateRecords
    {
        private static string _fullFileName;
        private static int _recordsProcessed;

        public static (string filePath, int recordsProcessed) RetrieveAndDeleteDuplicateRecords(IOrganizationService _crmService, DuplicateSearch duplicateSearch, bool deleteDuplicateRecords)
        {
            var results = RetrieveDuplicates(_crmService, duplicateSearch);

            if (deleteDuplicateRecords)
            {
                DeleteDuplicates(_crmService, results);
            }

            return (_fullFileName, _recordsProcessed);
        }

        /// <summary>
        /// Call the method to retrieve duplicate records.
        /// </summary>
        private static List<IGrouping<string, Entity>> RetrieveDuplicates(IOrganizationService _crmService, DuplicateSearch duplicateSearch)
        {
            QueryExpression query = GenerateQueryExpression(duplicateSearch.EntityLogicalName, duplicateSearch.DuplicatedColumnName, duplicateSearch.ColumnList.ToArray());
            Console.WriteLine("\n INFO: Finding duplicates is in progress ... \n");
            var results = _crmService.RetrieveAll(query)
                                            .OrderBy(e => e.GetAttributeValue<string>(duplicateSearch.DuplicatedColumnName))
                                            .ThenByDescending(e => e.GetAttributeValue<DateTime>("createdon"))
                                            .GroupBy(e => e.GetAttributeValue<string>(duplicateSearch.DuplicatedColumnName), e => e).ToList();

            WriteDuplicateRecordsInFile(results, duplicateSearch.EntityLogicalName);
            return results;
        }

        /// <summary>
        /// To delete the duplicate records with same unique ID field. It will keep the OLDEST record and delete the rest of them.
        /// </summary>
        /// <param name="crmService"></param>
        /// <param name="results"></param>
        private static void DeleteDuplicates(IOrganizationService crmService, List<IGrouping<string, Entity>> results)
        {
            Console.WriteLine("\n INFO: Deleting the duplicate records...");
            int deletedRecordCount = 0;
            using (StreamWriter writer = new StreamWriter(_fullFileName, append: true))
            {
                writer.WriteLine("\n====================");
                writer.WriteLine("Deleted records");
                writer.WriteLine("====================");

                foreach (var group in results)
                {
                    var recordCount = group.Count();
                    //If more than 1 records found with same TalentCompanyId
                    if (recordCount > 1)
                    {
                        var entities = group.ToArray();
                        for (int count = 0; count < entities.Count() - 1; count++)
                        {
                            crmService.Delete(entities[count].LogicalName, entities[count].Id);
                            writer.WriteLine(string.Format("Deleted record Id: {0}", entities[count].Id));
                            deletedRecordCount++;
                        }
                    }
                }
                writer.WriteLine(string.Format("Total deleted duplicate records: {0}", deletedRecordCount.ToString()));
                Console.WriteLine(string.Format(" INFO: Total {0} duplicate records deleted", deletedRecordCount.ToString()));
            }
        }

        /// <summary>
        /// This method will generate & return QueryExpression based in input parameters
        /// </summary>
        /// <param name="entityLogicalName"></param>
        /// <param name="duplicatedColumn"></param>
        /// <param name="columnsList"></param>
        /// <returns></returns>
        private static QueryExpression GenerateQueryExpression(string entityLogicalName, string duplicatedColumn, string[] columnsList)
        {
            QueryExpression query = new QueryExpression(entityLogicalName)
            {
                ColumnSet = new ColumnSet(columnsList)
            };
            return query;
        }

        /// <summary>
        /// To write the duplicate records in the file.
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        private static bool WriteDuplicateRecordsInFile(List<IGrouping<string, Entity>> results, string entityLogicalName)
        {
            try
            {
                string fileName = "DuplicateRecordDetails_" + entityLogicalName + "_" + DateTime.Now.ToString("yyyymmddhhmm") + ".txt";
                _fullFileName = Path.Combine(Environment.CurrentDirectory, fileName);

                Console.WriteLine(" INFO: Writing duplicate records to file...");
                int totalDuplicateRecords = 0;
                using (StreamWriter writer = new StreamWriter(_fullFileName))
                {
                    foreach (var group in results)
                    {
                        var recordCount = group.Count();
                        //If more than 1 records found with same TalentCompanyId
                        if (recordCount > 1)
                        {
                            foreach (var entity in group)
                            {
                                foreach (var attribute in entity.Attributes)
                                {
                                    writer.Write("{0} => {1} || ", attribute.Key, attribute.Value);
                                }
                                totalDuplicateRecords++;
                                writer.WriteLine("");
                            }
                        }
                    }
                    writer.WriteLine(string.Format("Total duplicate records: {0}", totalDuplicateRecords.ToString()));

                }
                _recordsProcessed = totalDuplicateRecords;
                Console.WriteLine(string.Format(" INFO: Total {0} duplicate records added in {1}", totalDuplicateRecords.ToString(), fileName.ToUpper()));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while writing in file: " + ex.ToString());
                return false;
            }
        }
    }

    public static class IOrganizationExtensions
    {

        /// <summary>
        /// Retrieve all entities from a query
        /// </summary>
        /// <param name="crmService">CRM connection to use</param>
        /// <param name="query">Query to execute</param>
        /// <returns>All <see cref="Entity"/> records from the query (from all pages)</returns>
        public static IEnumerable<Entity> RetrieveAll(this IOrganizationService crmService, QueryExpression query)
        {
            if (crmService == null)
            {
                throw new ArgumentNullException(nameof(crmService));
            }
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            if (query.TopCount.HasValue)
            {
                // You cannot use paging info with a top count
                var results = crmService.RetrieveMultiple(query);
                foreach (var entity in results.Entities) yield return entity;
            }
            else
            {
                EntityCollection results = null;
                query.PageInfo = new PagingInfo
                {
                    PageNumber = 1
                };
                do
                {
                    results = crmService.RetrieveMultiple(query);
                    query.PageInfo.PageNumber++;
                    query.PageInfo.PagingCookie = results.PagingCookie;
                    foreach (var entity in results.Entities) yield return entity;
                } while (results?.MoreRecords != false);
            }
        }
    }
}
