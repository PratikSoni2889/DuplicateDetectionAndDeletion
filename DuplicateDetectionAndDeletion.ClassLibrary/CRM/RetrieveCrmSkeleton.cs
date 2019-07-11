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
                ColumnSet = new ColumnSet(new string[] { "publisherid", "installedon", "version", "versionnumber", "friendlyname", "ismanaged", "uniquename"}),
                Criteria = new FilterExpression()
            };

            querySampleSolution.Criteria.AddCondition("uniquename".ToLower(), ConditionOperator.Like, "%" + solutionUniqueNameLike.ToLower() + "%");
            var solutions = service.RetrieveMultiple(querySampleSolution);
            if (solutions?.Entities?.Count > 0)
            {
                return solutions;
            }
            return null;
        }

        /// <summary>
        /// Returns list of Entities
        /// </summary>
        /// <param name="service"></param>
        /// <param name="solutionUniqueName"></param>
        /// <returns></returns>
        public List<EntityMetadata> GetEntityList(IOrganizationService service, string solutionUniqueName)
        {
            // get solution components for solution unique name
            QueryExpression componentsQuery = new QueryExpression
            {
                EntityName = "solutioncomponent",
                ColumnSet = new ColumnSet("objectid"),
                Criteria = new FilterExpression(),
            };
            LinkEntity solutionLink = new LinkEntity("solutioncomponent", "solution", "solutionid", "solutionid", JoinOperator.Inner);
            solutionLink.LinkCriteria = new FilterExpression();
            solutionLink.LinkCriteria.AddCondition(new ConditionExpression("uniquename", ConditionOperator.Equal, solutionUniqueName));
            componentsQuery.LinkEntities.Add(solutionLink);
            componentsQuery.Criteria.AddCondition(new ConditionExpression("componenttype", ConditionOperator.Equal, 1));
            EntityCollection ComponentsResult = service.RetrieveMultiple(componentsQuery);
            //Get all entities
            RetrieveAllEntitiesRequest AllEntitiesrequest = new RetrieveAllEntitiesRequest()
            {
                EntityFilters = EntityFilters.Entity | Microsoft.Xrm.Sdk.Metadata.EntityFilters.Attributes,
                RetrieveAsIfPublished = true
            };
            RetrieveAllEntitiesResponse AllEntitiesresponse = (RetrieveAllEntitiesResponse)service.Execute(AllEntitiesrequest);
            //Join entities Id and solution Components Id
            var entities = AllEntitiesresponse.EntityMetadata.Join(ComponentsResult.Entities.Select(x => x.Attributes["objectid"]), x => x.MetadataId, y => y, (x, y) => x);
            return entities.OrderBy(o => o.LogicalName).ToList();
        }

        /// <summary>
        /// Returns list of sorted attributes
        /// </summary>
        /// <param name="service"></param>
        /// <param name="entityLogicalName"></param>
        /// <returns></returns>
        public List<AttributeMetadata> GetAttributeList(IOrganizationService service, string entityLogicalName)
        {
            RetrieveEntityRequest retrieveEntityRequest = new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.Attributes,
                LogicalName = entityLogicalName
            };
            RetrieveEntityResponse retrieveAccountEntityResponse = (RetrieveEntityResponse)service.Execute(retrieveEntityRequest);
            EntityMetadata entityMetadata = retrieveAccountEntityResponse.EntityMetadata;
            var sortedAttributes = entityMetadata.Attributes.OrderBy(o => o.LogicalName).ToList();
            return sortedAttributes;
        }
    }
}