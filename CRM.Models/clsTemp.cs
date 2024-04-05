using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZMasterSetup;
using System.Web.Mvc;

namespace CRM.Models
{
    public class clsTemp
    {
      

            clsCommonFuntions CommonFuntions;
            clsCreateEditUserRequestHandler createEditUserRequestHandler;
            //public string connectionString = "Dsn=EzERP;uid=ezbusdb;pwd=easybusdb";
            public string ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;
            static List<SelectListItem> ConvertDataSetToSelectList(DataSet dataSet, string dropdownTextColumn, string dropdownValueColumn)
            {
                List<SelectListItem> selectListItems = new List<SelectListItem>();

                // Check if the DataSet and DataTable exist
                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    DataTable dataTable = dataSet.Tables[0];

                    // Iterate through the rows of the DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create a SelectListItem for each row
                        SelectListItem item = new SelectListItem
                        {
                            Text = row[dropdownTextColumn].ToString(),
                            Value = row[dropdownValueColumn].ToString()
                        };

                        // Add the SelectListItem to the list
                        selectListItems.Add(item);
                    }
                }

                return selectListItems;
            }

            public List<SelectListItem> FillControls(string TableName, string dropdownTextColumn, string dropdownValueColumn, string CmpyCode = "", string OrderBy = "", string condition = "")
            {
                CommonFuntions = new clsCommonFuntions();
                List<SelectListItem> lstList = new List<SelectListItem>();
                if (dropdownValueColumn != "" || dropdownTextColumn != "")
                {
                    string strQuery;
                    if (condition != "")
                    {
                        strQuery = "Select " + dropdownValueColumn + "," + dropdownTextColumn + " from " + TableName;
                        if (CmpyCode == "")
                        {
                            strQuery = strQuery + " where " + condition;
                        }
                        else
                        {
                            strQuery = strQuery + " where CmpyCode = '" + CmpyCode + "' and " + condition;
                        }
                        //strQuery = "Select " + dropdownValueColumn + "," + dropdownTextColumn + " from " + TableName + (CmpyCode == "" ? "" : " where CmpyCode='" + CmpyCode + "'") + (CmpyCode == "" ? "" : " and CmpyCode='" + CmpyCode + "'") + (OrderBy == "" ? "" : " " + OrderBy + ""); ;
                    }
                    else
                    {
                        strQuery = "Select " + dropdownValueColumn + "," + dropdownTextColumn + " from " + TableName + (CmpyCode == "" ? "" : " where CmpyCode='" + CmpyCode + "'") + (OrderBy == "" ? "" : " " + OrderBy + ""); ;
                    }
                    lstList = ConvertDataSetToSelectList(CommonFuntions.ExecuteQueryDataset(strQuery), dropdownTextColumn, dropdownValueColumn);
                }
                return (lstList);
            }

            public bool validateUserLogin(string UserName, string Password, string cmpyCode)
            {
                CommonFuntions = new clsCommonFuntions();
                string intCount = CommonFuntions.GF_Get_CodeNew("Users", " LoginUserName='" + UserName + "' and Loginpassword='" + Password + "'", "Count(LoginUserName)", cmpyCode);
                if (Convert.ToInt32(intCount) > 0)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            }

            public DataTable GetData_Into_DataTable(string tableName, string idColumnName, string Id, string strCmpyCode)
            {
                CommonFuntions = new clsCommonFuntions();
                DataTable dataTable = CommonFuntions.GetAllData_DataTable(tableName, idColumnName, Id, strCmpyCode);
                return (dataTable);
            }

            public clsControlsVM GetData_In_EditMode(string SectionId, string Id, string userName, string PrimaryColumnName, string CmpyCode)
            {
                try
                {


                    createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                    clsControlsVM ControlsVM = createEditUserRequestHandler.CreateHandler(SectionId, userName);


                    List<clsControls> controls = new List<clsControls>();
                    List<clsControls> controlsTemp;
                    List<clsControls> controlsCurrentRecord;
                    clsEzTemplateMasterBAL EzTemplateMasterBAL = new clsEzTemplateMasterBAL();

                    foreach (var item in ControlsVM.sectionMaster)
                    {
                        DataTable dataTable = GetData_Into_DataTable(item.SectionCode, PrimaryColumnName, Id, CmpyCode);
                        controlsTemp = new List<clsControls>();
                        foreach (var control in ControlsVM.controls.Where(e => e.SectionCode == item.SectionCode))
                        {
                            controlsTemp.Add(control);
                        }
                        foreach (DataRow row in dataTable.Rows)
                        {
                            controlsCurrentRecord = new List<clsControls>();
                            controlsCurrentRecord = createEditUserRequestHandler.FillValuesInRespectiveControls_Detail(row, controlsTemp, item.SectionCode);
                            foreach (var controlNew in controlsCurrentRecord)
                            {
                                // Create a new instance of clsControls
                                clsControls singleControls = new clsControls();
                                // Copy properties from controlNew to the new instance
                                CopyProperties(controlNew, singleControls);
                                // Add the new instance to the controls list
                                controls.Add(singleControls);
                            }
                        }
                    }
                    ControlsVM.controls = controls;
                    ControlsVM.ezTemplateMaster = EzTemplateMasterBAL.GetByIdList(SectionId);

                    return (ControlsVM);
                }
                catch
                {

                    throw;
                }
            }

            public clsControlsVM GetData_In_EditMode_CommonMaster(string SectionId, string Id, string userName, string PrimaryColumnName, string CmpyCode)
            {
                try
                {


                    createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                    clsControlsVM ControlsVM = createEditUserRequestHandler.CreateHandler(SectionId, userName, CmpyCode);


                    List<clsControls> controls = new List<clsControls>();
                    List<clsControls> controlsTemp;
                    List<clsControls> controlsCurrentRecord;
                    clsEzTemplateMasterBAL EzTemplateMasterBAL = new clsEzTemplateMasterBAL();

                    foreach (var item in ControlsVM.sectionMaster)
                    {
                        DataTable dataTable = GetData_Into_DataTable("EzCommonMaster", PrimaryColumnName, Id, CmpyCode);
                        controlsTemp = new List<clsControls>();
                        foreach (var control in ControlsVM.controls.Where(e => e.SectionCode == item.SectionCode))
                        {
                            controlsTemp.Add(control);
                        }
                        foreach (DataRow row in dataTable.Rows)
                        {
                            controlsCurrentRecord = new List<clsControls>();
                            controlsCurrentRecord = createEditUserRequestHandler.FillValuesInRespectiveControls_Detail(row, controlsTemp, item.SectionCode);
                            foreach (var controlNew in controlsCurrentRecord)
                            {
                                // Create a new instance of clsControls
                                clsControls singleControls = new clsControls();
                                // Copy properties from controlNew to the new instance
                                CopyProperties(controlNew, singleControls);
                                // Add the new instance to the controls list
                                controls.Add(singleControls);
                            }
                        }
                    }
                    ControlsVM.controls = controls;
                    ControlsVM.ezTemplateMaster = EzTemplateMasterBAL.GetByIdList(SectionId);

                    return (ControlsVM);
                }
                catch
                {

                    throw;
                }
            }

            public clsControlsVM GetData_In_CreateMode(string tableOrViewName, string SectionId, string userName, string PrimaryColumnName, string CmpyCode)
            {
                try
                {


                    createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                    clsControlsVM ControlsVM = createEditUserRequestHandler.CreateHandler(SectionId, userName);


                    List<clsControls> controls = new List<clsControls>();
                    List<clsControls> controlsTemp;
                    List<clsControls> controlsCurrentRecord;
                    clsEzTemplateMasterBAL EzTemplateMasterBAL = new clsEzTemplateMasterBAL();

                    foreach (var item in ControlsVM.sectionMaster)
                    {
                        DataTable dataTable = GetData_Into_DataTable(tableOrViewName, PrimaryColumnName, item.SectionCode, CmpyCode);
                        controlsTemp = new List<clsControls>();
                        foreach (var control in ControlsVM.controls.Where(e => e.SectionCode == item.SectionCode))
                        {
                            controlsTemp.Add(control);
                        }
                        if (dataTable.Rows.Count == 0) //For section whose values are not passed
                        {
                            controlsCurrentRecord = new List<clsControls>();
                            foreach (var controlNew in controlsTemp)
                            {
                                clsControls singleControls = new clsControls();
                                // Copy properties from controlNew to the new instance
                                CopyProperties(controlNew, singleControls);
                                controls.Add(singleControls);
                            }
                        }
                        else
                        {
                            foreach (DataRow row in dataTable.Rows)
                            {
                                controlsCurrentRecord = new List<clsControls>();
                                controlsCurrentRecord = createEditUserRequestHandler.FillValuesInRespectiveControls_Detail(row, controlsTemp, item.SectionCode);
                                foreach (var controlNew in controlsCurrentRecord)
                                {
                                    // Create a new instance of clsControls
                                    clsControls singleControls = new clsControls();
                                    // Copy properties from controlNew to the new instance
                                    CopyProperties(controlNew, singleControls);
                                    // Add the new instance to the controls list
                                    controls.Add(singleControls);
                                }
                            }
                        }
                    }
                    ControlsVM.controls = controls;
                    ControlsVM.ezTemplateMaster = EzTemplateMasterBAL.GetByIdList(SectionId);

                    return (ControlsVM);
                }
                catch
                {

                    throw;
                }
            }

            public object CopyProperties(object source, object destination)
            {
                var sourceProperties = source.GetType().GetProperties();
                var destinationProperties = destination.GetType().GetProperties();

                foreach (var sourceProperty in sourceProperties)
                {
                    var destinationProperty = destinationProperties.FirstOrDefault(x => x.Name == sourceProperty.Name);

                    if (destinationProperty != null && destinationProperty.CanWrite)
                    {
                        var value = sourceProperty.GetValue(source, null);
                        destinationProperty.SetValue(destination, value, null);
                    }
                }

                return destination;
            }

            public String GF_Get_AutoCode_ParamTable(string Mode, String Code, string CmpyCode)
            {
                String AutoNumber = "";
                clsDBHelperBAL dbHelperBAL = new clsDBHelperBAL();
                DataTable CodeSet1 = GetData_Into_DataTable("ParamTable", "Code", Code, CmpyCode);// ("Select * from ParamTable where CmpyCode='" + CmpyCode + "' and BranchCode='" + BranchCode + "' and Code='" + Code + "'");
                IDataReader rd;
                rd = CodeSet1.CreateDataReader();
                if (rd.Read())
                {
                    if (rd["Auto"].ToString() == "Y")
                    {
                        var LastNo = double.Parse(rd["Nos"].ToString()) + 1;
                        var PreFix = rd["Name"].ToString();


                        String StrFormat = "";
                        for (int i = 1; i <= double.Parse(rd["TotalDigits"].ToString()); i++)
                        {
                            StrFormat = string.Concat(StrFormat, "0");
                        }
                        StrFormat = string.Concat(StrFormat, LastNo.ToString());
                        //StrFormat = StrFormat.Substring(LastNo.ToString().Length+1, int.Parse(CodeSet1.Digit.ToString()))
                        StrFormat = StrFormat.Substring(LastNo.ToString().Length);
                        AutoNumber = string.Concat(PreFix, StrFormat);
                        if (Mode == "SAVE")
                        {
                            dbHelperBAL.connectionString = ConnString;
                            dbHelperBAL.ExecuteNonQuery("Update ParamTable set Nos= " + LastNo + " where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
                            //GF_Execute_Query("Update ParamTable set Nos= " + LastNo + " where CmpyCode='" + CmpyCode + "' and BranchCode='" + BranchCode + "' and Code='" + Code + "'");
                        }
                    }
                    else
                    {
                        AutoNumber = "";
                    }
                }
                else
                {
                    AutoNumber = "";
                }
                return (AutoNumber);
            }




        }


    }
