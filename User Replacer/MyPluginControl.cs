using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace User_Replacer
{
    public partial class MyPluginControl : PluginControlBase
    {
        private Settings mySettings;
        private IOrganizationService _service;

        private EntityCollection ecOldUser;
        private EntityCollection ecNewUser;
        EntityCollection ecOwners;
        readonly ArrayList Entities = new ArrayList();

        public MyPluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }

            buttonSearchOwner.Enabled = false;
            buttonSearchCustom.Enabled = false;
            buttonReplace.Enabled = false;
            buttonReplaceCustom.Enabled = false;
            buttonCompareRoles.Enabled = false;
            buttonCompareTeams.Enabled = false;
        }



        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
            _service = newService;
        }

        private void ButtonResolveUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxOldUser.Text) || string.IsNullOrEmpty(textBoxNewUser.Text))
            {
                MessageBox.Show("Please enter a value in both fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            buttonCompareRoles.Enabled = true;
            buttonCompareTeams.Enabled = true;

            listViewOldUser.Clear();
            listViewNewUser.Clear();

            string attribute;
            if (checkBoxResolveEmail.Checked)
            {
                attribute = "internalemailaddress";
            }
            else
            {
                attribute = "fullname";
            }
            QueryExpression qeOldUser = new QueryExpression("systemuser")
            {
                TopCount = 5,
                ColumnSet = new ColumnSet("fullname", "systemuserid"),
                Criteria = new FilterExpression(LogicalOperator.And)
                {
                    Conditions = {
                        new ConditionExpression(attributeName:attribute, conditionOperator: ConditionOperator.BeginsWith, value: textBoxOldUser.Text)
                    }
                }
            };
            try
            {
                ecOldUser = _service.RetrieveMultiple(qeOldUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            QueryExpression qeNewUser = new QueryExpression("systemuser")
            {
                TopCount = 5,
                ColumnSet = new ColumnSet("fullname", "systemuserid"),
                Criteria = new FilterExpression(LogicalOperator.And)
                {
                    Conditions = {
                        new ConditionExpression(attributeName:"fullname", conditionOperator: ConditionOperator.BeginsWith, value: textBoxNewUser.Text)
                    }
                }
            };
            try
            {
                ecNewUser = _service.RetrieveMultiple(qeNewUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            listViewOldUser.View = View.Details;
            listViewOldUser.Columns.Add("Name", 150);
            listViewOldUser.Columns.Add("ID", 0);

            listViewNewUser.View = View.Details;
            listViewNewUser.Columns.Add("Name", 150);
            listViewNewUser.Columns.Add("ID", 0);

            listViewOldUser.Items.AddRange(ecOldUser.Entities.Select(entity => new ListViewItem(new[] { entity.GetAttributeValue<string>("fullname"), entity.Id.ToString() })).ToArray());
            listViewNewUser.Items.AddRange(ecNewUser.Entities.Select(entity => new ListViewItem(new[] { entity.GetAttributeValue<string>("fullname"), entity.Id.ToString() })).ToArray());
        }

        private void ButtonReplace_Click(object sender, EventArgs e)
        {
            foreach (var entity in ecOwners.Entities)
            {
                entity["ownerid"] = new EntityReference("systemuser", Guid.Parse(listViewNewUser.SelectedItems[0].SubItems[1].Text));
                _service.Update(entity);
            }
        }

        private void CheckedListBoxEntities_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            buttonSearchOwner.Enabled = true;
            buttonReplace.Enabled = true;

            if (e.NewValue == CheckState.Checked)
            {
                Entities.Add(checkedListBoxEntities.Items[e.Index].ToString());
            }
            else
            {
                Entities.Remove(checkedListBoxEntities.Items[e.Index].ToString());
            }
        }

        private void ButtonReplaceCustom_Click(object sender, EventArgs e)
        {
            EntityCollection ecResults = new EntityCollection();
            foreach (DataGridViewRow row in dataGridViewCustomEntities.Rows)
            {
                string sEntity = (string)row.Cells[0].Value;
                string sField = (string)row.Cells[1].Value;
                QueryExpression qeResults = new QueryExpression(sEntity)
                {
                    ColumnSet = new ColumnSet(sField),
                    Criteria = new FilterExpression(LogicalOperator.And)
                    {
                        Conditions = {
                            new ConditionExpression(attributeName: sField, conditionOperator: ConditionOperator.Equal, value: listViewOldUser.SelectedItems[0].SubItems[1].Text)
                        }
                    }
                };
                try
                {
                    ecResults = _service.RetrieveMultiple(qeResults);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                foreach (var entity in ecResults.Entities)
                {
                    entity["ownerid"] = new EntityReference("systemuser", Guid.Parse(listViewNewUser.SelectedItems[0].SubItems[1].Text));
                    try
                    {
                        _service.Update(entity);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }   
        }

        private void ButtonSearchOwner_Click(object sender, EventArgs e)
        {
            foreach (string Entityname in Entities)
            {
                QueryExpression qeOwnerResults = new QueryExpression(Entityname)
                {
                    ColumnSet = new ColumnSet("ownerid", "name"),
                    Criteria = new FilterExpression(LogicalOperator.And)
                    {
                        Conditions = {
                        new ConditionExpression(attributeName:"ownerid", conditionOperator: ConditionOperator.Equal, value: listViewOldUser.SelectedItems[0].SubItems[1].Text)
                    }
                    }
                };
                try
                {
                ecOwners = _service.RetrieveMultiple(qeOwnerResults);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                DisplayResults(ecOwners);
            }
        }

        private void ButtonSearchCustom_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewCustomEntities.Rows)
            {
                string sEntity = (string)row.Cells[0].Value;
                string sField = (string)row.Cells[1].Value;
                if (sField == null && sEntity == null)
                {
                    continue;
                }
                QueryExpression qeResults = new QueryExpression(sEntity)
                {
                    ColumnSet = new ColumnSet(sField),
                    Criteria = new FilterExpression(LogicalOperator.And)
                    {
                        Conditions = {
                            new ConditionExpression(attributeName: sField, conditionOperator: ConditionOperator.Equal, value: listViewOldUser.SelectedItems[0].SubItems[1].Text)
                        }
                    }
                };
                try
                {
                    EntityCollection ecResults = _service.RetrieveMultiple(qeResults);
                    DisplayResults(ecResults);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ButtonCompareRoles_Click(object sender, EventArgs e)
        {
            if (listViewOldUser.FocusedItem == null || listViewNewUser.FocusedItem == null)
            {
                MessageBox.Show("Please pick a user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            QueryExpression qeOldUser = new QueryExpression("role") { ColumnSet = new ColumnSet("name", "roleid"), LinkEntities = 
            {
                new LinkEntity
                {
                    LinkFromEntityName = "role", LinkFromAttributeName = "roleid", LinkToEntityName = "systemuserroles", LinkToAttributeName = "roleid",
                    LinkEntities =
                    {
                        new LinkEntity
                        {
                            LinkFromEntityName = "systemuserroles", LinkFromAttributeName = "systemuserid", LinkToEntityName = "systemuser", LinkToAttributeName = "systemuserid",
                            LinkCriteria = new FilterExpression
                            {
                                Conditions = { new ConditionExpression("systemuserid", ConditionOperator.Equal, listViewOldUser.SelectedItems[0].SubItems[1].Text) }
                            }
                        }
                    }
                }
            }
            };
            try
            {
                EntityCollection ecRolesOld = _service.RetrieveMultiple(qeOldUser);
                DisplayResults(ecRolesOld, listViewOldUser.SelectedItems[0].SubItems[0].Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            QueryExpression qeNewUser = new QueryExpression("role")
            {
                ColumnSet = new ColumnSet("name", "roleid"),
                LinkEntities =
            {
                new LinkEntity
                {
                    LinkFromEntityName = "role", LinkFromAttributeName = "roleid", LinkToEntityName = "systemuserroles", LinkToAttributeName = "roleid",
                    LinkEntities =
                    {
                        new LinkEntity
                        {
                            LinkFromEntityName = "systemuserroles", LinkFromAttributeName = "systemuserid", LinkToEntityName = "systemuser", LinkToAttributeName = "systemuserid",
                            LinkCriteria = new FilterExpression
                            {
                                Conditions = { new ConditionExpression("systemuserid", ConditionOperator.Equal, listViewNewUser.SelectedItems[0].SubItems[1].Text) }
                            }
                        }
                    }
                }
            }
            };
            try
            {
                EntityCollection ecRolesNew = _service.RetrieveMultiple(qeNewUser);
                DisplayResults(ecRolesNew, listViewNewUser.SelectedItems[0].SubItems[0].Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void ButtonCompareTeams_Click_1(object sender, EventArgs e)
        {
            if (listViewOldUser.FocusedItem == null || listViewNewUser.FocusedItem == null)
            {
                MessageBox.Show("Please pick a user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var qeTeamsOld = new QueryExpression("team");
            qeTeamsOld.ColumnSet.AddColumn("name");
            var query_teammembership = qeTeamsOld.AddLink("teammembership", "teamid", "teamid");


            query_teammembership.LinkCriteria.AddCondition("systemuserid", ConditionOperator.Equal, listViewOldUser.SelectedItems[0].SubItems[1].Text);
            
            try
            {
                EntityCollection ecTeamsOld = _service.RetrieveMultiple(qeTeamsOld);
                DisplayResults(ecTeamsOld, listViewOldUser.SelectedItems[0].SubItems[0].Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var qeTeamsNew = new QueryExpression("team");
            qeTeamsNew.ColumnSet.AddColumn("name");
            var query_teammembershipNew = qeTeamsNew.AddLink("teammembership", "teamid", "teamid");


            query_teammembershipNew.LinkCriteria.AddCondition("systemuserid", ConditionOperator.Equal, listViewNewUser.SelectedItems[0].SubItems[1].Text);
            try
            {
                EntityCollection ecTeamsNew = _service.RetrieveMultiple(qeTeamsNew);
                DisplayResults(ecTeamsNew, listViewNewUser.SelectedItems[0].SubItems[1].Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void DataGridViewCustomEntities_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            buttonSearchCustom.Enabled = true;
            buttonReplaceCustom.Enabled = true;
        }

        private void DisplayResults (EntityCollection ecResults, string sTitle = null)
        {
            if (ecResults == null)
            {
                return;
            }
            if (sTitle == null)
            {
                sTitle = ecResults.EntityName;
            }
            DisplayResultsForm ResultsForm = new DisplayResultsForm
            {
                Text = sTitle
            };
            foreach (Entity eEntity in ecResults.Entities)
            {
                ResultsForm.DisplayResultsDataGriedView.Rows.Add(eEntity.Id, eEntity.GetAttributeValue<string>("name"));
            }
            ResultsForm.Show();
        }

        private void buttonLoadEntities_Click(object sender, EventArgs e)
        {
            var request = new RetrieveAllEntitiesRequest
            {
                EntityFilters = EntityFilters.Entity
            };

            try
            {
                var response = (RetrieveAllEntitiesResponse)_service.Execute(request);
                var entities = response.EntityMetadata.Select(em => em.LogicalName).OrderBy(name => name).ToList();
                checkedListBoxEntities.DataSource = entities;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}