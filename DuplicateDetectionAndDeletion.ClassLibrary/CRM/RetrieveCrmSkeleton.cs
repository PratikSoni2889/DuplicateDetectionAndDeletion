using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateDetectionAndDeletion.ClassLibrary.CRM
{
    public class RetrieveCrmSkeleton
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

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
