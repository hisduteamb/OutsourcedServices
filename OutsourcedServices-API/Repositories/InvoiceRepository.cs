using System;
using Model;
using Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using YourNamespace.Models;
using Microsoft.Extensions.Configuration;
using System.Numerics;

namespace Repositories
{
    public class InvoiceRepository
    {
        private readonly IConfiguration _configuration;
        private readonly GenericRepository _genericRepository;
        private readonly string _connectionString;
        public InvoiceRepository(GenericRepository genericRepository, IConfiguration configuration)
        {
            _genericRepository = genericRepository;
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            
        }

        public void SaveInvoice(InvoiceViewModel invoice)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Create the InvoiceMaster DataTable
                DataTable invoiceMasterTable = CreateInvoiceMasterDataTable();
                DataRow invoiceMasterRow = invoiceMasterTable.NewRow();
                invoiceMasterRow["TrackingNumber"] = invoice.TrackingNumber;
                if (invoice.StatusId.HasValue)
                {
                    invoiceMasterRow["Status_Id"] = invoice.StatusId;
                }
                else
                {
                    invoiceMasterRow["Status_Id"] = Convert.DBNull;
                }
                
                invoiceMasterRow["StatusDatetime"] = invoice.StatusDatetime;
                invoiceMasterRow["Amount"] = invoice.Amount;
                invoiceMasterRow["Comments"] = invoice.Comments;
                invoiceMasterRow["CurrentOfficer_Id"] = invoice.CurrentOfficerId;
                invoiceMasterRow["Company_Id"] = invoice.CompanyId;
                invoiceMasterRow["OutsourceService_Id"] = invoice.OutsourceServiceId;
                if (invoice.IsReceived.HasValue)
                {
                    invoiceMasterRow["IsReceived"] = invoice.IsReceived;
                }
                else
                {
                    invoiceMasterRow["IsReceived"] = Convert.DBNull;
                }

                
                invoiceMasterRow["ReceiveDatetime"] = invoice.ReceiveDatetime;
                if (invoice.IsActive.HasValue)
                {
                    invoiceMasterRow["IsActive"] = invoice.IsActive;
                }
                else
                {
                    invoiceMasterRow["IsActive"] = Convert.DBNull;
                }
                invoiceMasterRow["CreatedDate"] = DateTime.UtcNow.AddHours(5);
                invoiceMasterRow["CreatedBy"] = invoice.CreatedBy;
                invoiceMasterRow["User_Id"] = invoice.User_Id;
                invoiceMasterTable.Rows.Add(invoiceMasterRow);

                // Create the InvoiceDetail DataTable
                DataTable invoiceDetailTable = CreateInvoiceDetailDataTable();
                foreach (var item in invoice.InvoiceDetail)
                {
                    DataRow invoiceDetailRow = invoiceDetailTable.NewRow();
                    invoiceDetailRow["InvoiceMaster_Id"] = item.InvoiceMaster_Id;
                    invoiceDetailRow["Staff_Id"] = item.StaffId;
                    invoiceDetailRow["Item_Id"] = item.ItemId;
                    invoiceDetailRow["Quantity"] = item.Quantity;
                    invoiceDetailRow["AttendanceInDays"] = item.AttendanceInDays;
                    invoiceDetailRow["IsActive"] = item.IsActive;
                    invoiceDetailRow["CreatedDate"] = DateTime.UtcNow.AddHours(5);
                    invoiceDetailRow["CreatedBy"] = invoice.CreatedBy;
                    invoiceDetailRow["User_Id"] = invoice.User_Id;
                    invoiceDetailTable.Rows.Add(invoiceDetailRow);
                }

                // Execute the stored procedure
                ExecuteStoredProcedure(invoiceMasterTable, invoiceDetailTable, connection);
            }
        }

        private DataTable CreateInvoiceMasterDataTable()
        {
            DataTable invoiceMasterTable = new DataTable("InvoiceMaster");
            invoiceMasterTable.Columns.Add("TrackingNumber", typeof(long));
            invoiceMasterTable.Columns.Add("Status_Id", typeof(int));
            invoiceMasterTable.Columns.Add("StatusDatetime", typeof(DateTime));
            invoiceMasterTable.Columns.Add("Amount", typeof(decimal));
            invoiceMasterTable.Columns.Add("Comments", typeof(string));
            invoiceMasterTable.Columns.Add("CurrentOfficer_Id", typeof(int));
            invoiceMasterTable.Columns.Add("Company_Id", typeof(int));
            invoiceMasterTable.Columns.Add("OutsourceService_Id", typeof(int));
            invoiceMasterTable.Columns.Add("IsReceived", typeof(bool));
            invoiceMasterTable.Columns.Add("ReceiveDatetime", typeof(DateTime));
            invoiceMasterTable.Columns.Add("IsActive", typeof(bool));
            invoiceMasterTable.Columns.Add("CreatedDate", typeof(DateTime));
            invoiceMasterTable.Columns.Add("CreatedBy", typeof(string));
            invoiceMasterTable.Columns.Add("User_Id", typeof(string));
            return invoiceMasterTable;
        }

        private DataTable CreateInvoiceDetailDataTable()
        {
            DataTable invoiceDetailTable = new DataTable("InvoiceDetail");
            invoiceDetailTable.Columns.Add("InvoiceMaster_Id",typeof(int));
            invoiceDetailTable.Columns.Add("Staff_Id", typeof(int));
            invoiceDetailTable.Columns.Add("Item_Id", typeof(int));
            invoiceDetailTable.Columns.Add("Quantity", typeof(int));
            invoiceDetailTable.Columns.Add("AttendanceInDays", typeof(int));
            invoiceDetailTable.Columns.Add("IsActive", typeof(bool));
            invoiceDetailTable.Columns.Add("CreatedDate", typeof(DateTime));
            invoiceDetailTable.Columns.Add("CreatedBy", typeof(string));
            invoiceDetailTable.Columns.Add("User_Id", typeof(string));
            return invoiceDetailTable;
        }

        private void ExecuteStoredProcedure(DataTable invoiceMasterTable, DataTable invoiceDetailTable, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("sp_Invoice_CRUD", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter invoiceMasterParam = command.Parameters.AddWithValue("@InvoiceMaster", invoiceMasterTable);
                invoiceMasterParam.SqlDbType = SqlDbType.Structured;
                invoiceMasterParam.TypeName = "dbo.InvoiceMasterType";

                SqlParameter invoiceDetailParam = command.Parameters.AddWithValue("@InvoiceDetail", invoiceDetailTable);
                invoiceDetailParam.SqlDbType = SqlDbType.Structured;
                invoiceDetailParam.TypeName = "dbo.InvoiceDetailType";

                command.ExecuteNonQuery();
            }
        }


    }
}
