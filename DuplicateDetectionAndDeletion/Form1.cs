using DuplicateDetectionAndDeletion.ClassLibrary.CRM;
using DuplicateDetectionAndDeletion.ClassLibrary.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DuplicateDetectionAndDeletion
{
    /// <summary>
    /// This windows application will interact with Class Library and uses the results to display it over the form...
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly CRMConnection _service = new CRMConnection();
        private IOrganizationService _context;
        private readonly RetrieveCrmSkeleton _retrieveCrmSkeleton = new RetrieveCrmSkeleton();


        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnCRMConnect_Click(object sender, EventArgs e)
        {
            cbxSolution.Items.Clear();
            cbxEntities.Items.Clear();

            CRMCredential crmCredential = new CRMCredential()
            {
                Url = txtUrl.Text,
                SolutionName = txtSolutionName.Text,
                UserName = txtUserName.Text,
                Password = txtPassword.Text
            };

            // Establishes the CRM connection
            _context = _service.EstablishCRMConnection(crmCredential);

            // Log = "Connected successfully to CRM."

            var solutions = _retrieveCrmSkeleton.GetSolutions(_context, crmCredential.SolutionName);

            if (!solutions.Entities.Any())
            {
                MessageBox.Show("No solution found.\n Please try with other UrlName", "Dynamics 365", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSolutionName.Focus();
                return;
            }

            foreach (var entity in solutions.Entities)
            {
                cbxSolution.Items.Add(entity.Attributes["friendlyname"] + " [" + entity.Attributes["uniquename"] + "]");
            }

            MessageBox.Show("Solution(s) loaded", "Dynamics 365", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CbxSolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            var startIndex = cbxSolution.SelectedItem.ToString().IndexOf("[");
            var substringLength = cbxSolution.SelectedItem.ToString().Length - 2 - startIndex;
            var solutionUniqueName = cbxSolution.SelectedItem.ToString().Substring(startIndex + 1, substringLength);

            var allEntities = _retrieveCrmSkeleton.GetEntityList(_context, solutionUniqueName);

            if (!allEntities.Any())
            {
                MessageBox.Show("No entities found for selected solution.\n Please try with other solution.", "Dynamics 365", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSolutionName.Focus();
                return;
            }

            foreach (EntityMetadata entity in allEntities)
            {
                cbxEntities.Items.Add(entity.LogicalName);
            }
            MessageBox.Show("Entity(s) loaded", "Dynamics 365", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CbxEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            var attributes = _retrieveCrmSkeleton.GetAttributeList(_context, cbxEntities.SelectedItem.ToString());

            if (!attributes.Any())
            {
                MessageBox.Show("No attributes found.", "Dynamics 365", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSolutionName.Focus();
                return;
            }

            foreach (var attribute in attributes)
            {
                clbxAttributes.Items.Add(attribute.LogicalName);
                cbxKeyColumn.Items.Add(attribute.LogicalName);
            }
            MessageBox.Show("Attribute(s) loaded", "Dynamics 365", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        private void BtnDetectDuplicates_Click(object sender, EventArgs e)
        {
            List<Key> keyList = new List<Key>();
            var keyAttributes = new List<string>();

            foreach (object itemChecked in clbxAttributes.CheckedItems)
            {
                keyAttributes.Add(itemChecked.ToString());
            }

            DuplicateSearch duplicateSearch = new DuplicateSearch()
            {
                EntityLogicalName = cbxEntities.SelectedItem.ToString(),
                DuplicatedColumnName = cbxKeyColumn.SelectedItem.ToString(),
                ColumnList = keyAttributes
            };

            DuplicateRecords.RetrieveAndDeleteDuplicateRecords(_context, duplicateSearch, true);
        }
    }

    /// <summary>
    /// IEquatable class to handle the key attributes selected for duplicate detection & deletion
    /// </summary>
    public class Key : IEquatable<Key>
    {
        private Dictionary<string, object> _values = new Dictionary<string, object>();
        public Key(Dictionary<string, object> values)
        {
            _values = values;
        }
        public bool Equals(Key other)
        {
            if (other == null) return false;
            foreach (var value in _values)
            {
                if (!other._values.TryGetValue(value.Key, out var otherValue)) return false;
                if (!value.Value.Equals(otherValue)) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                foreach (var value in _values)
                {
                    hashCode = (hashCode ^ value.Value.GetHashCode());
                }

                return hashCode;

            }
        }

        public override string ToString() => _values.Select(kv => $"{kv.Key}={kv.Value}").Aggregate((a, c) => $"{a},{c}");
    }
}