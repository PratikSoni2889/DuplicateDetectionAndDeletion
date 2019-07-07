using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using NLog;
using System.Collections.Generic;
using System.Linq;

namespace DuplicateDetectionAndDeletion.ClassLibrary.CRM
{
    public class RetrieveCrmSkeleton
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public EntityCollection GetSolutions(IOrganizationService service, string solutionUniqueNameLike)
        {
            QueryExpression querySampleSolution = new QueryExpression
            {
                EntityName = "solution",
                ColumnSet = new ColumnSet(new string[] { "publisherid", "installedon", "version", "versionnumber", "friendlyname", "ismanaged", "uniquename" }),
                Criteria = new FilterExpression()
            };

            querySampleSolution.Criteria.AddCondition("uniquename".ToLower(), ConditionOperator.Like, "*" + solutionUniqueNameLike.ToLower() + "*");
            var solutions = service.RetrieveMultiple(querySampleSolution);
            //var filteredSolutiions = solutions.Entities.Where(e => (e.Attributes.Contains("uniquename")) && (e.Attributes["uniquename"].ToString().ToLower() == "*" + solutionUniqueNameLike + "*"));
            if (solutions?.Entities?.Count > 0)
            {
                return solutions;
            }
            return null;
        }

        public EntityMetadata[] GetEntityList(IOrganizationService service)
        {
            _logger.Trace("Started fetching entitites.");
            Dictionary<string, string> attributesData = new Dictionary<string, string>();
            RetrieveAllEntitiesRequest metaDataRequest = new RetrieveAllEntitiesRequest();
            RetrieveAllEntitiesResponse metaDataResponse = new RetrieveAllEntitiesResponse();
            metaDataRequest.EntityFilters = EntityFilters.Entity;

            // Execute the request.

            metaDataResponse = (RetrieveAllEntitiesResponse)service.Execute(metaDataRequest);
            _logger.Debug("Request executed successfully.");
            var entities = metaDataResponse.EntityMetadata;
            if (entities == null)
            {
                _logger.Info("No entities found for current CRM connection.");
            }
            return entities;
        }
    }
}
