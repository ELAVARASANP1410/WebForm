using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using PaymentForm.DAL.Entities;

namespace PaymentForm.Controllers
{
    [Route("api/[controller]/[action]")]
    public class VoucherMaster1Controller : Controller
    {
        private ERPMasterWtDataContext _context;

        public VoucherMaster1Controller(ERPMasterWtDataContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var tbl201vouchermasters = _context.Tbl201VoucherMasters.Select(i => new {
                i.VoucherNo,
                i.VoucherDate,
                i.VoucherRefNo,
                i.VoucherNarration,
                i.VoucherEnteredBy,
                i.VoucherEnteredOn,
                i.VoucherVerifiedBy,
                i.VoucherVerifiedOn,
                i.IsVerified,
                i.VoucherApprovedBy,
                i.VoucherApprovedOn,
                i.IsApproved,
                i.VoucherType,
                i.VoucherEffectiveDate,
                i.InvoiceSubmittedDate,
                i.InvoiceDueDate,
                i.InvoiceNoOfDays,
                i.UseSubmittedDate,
                i.SalesPersonCode,
                i.BillNo,
                i.BillDate,
                i.BillPaidTo,
                i.BillRemarks,
                i.VoucherModifiedBy,
                i.VoucherModifiedOn,
                i.AuditVerifiedBy,
                i.AuditVerifiedOn,
                i.IsAuditVerified,
                i.DeliveryNoteNo,
                i.CogsInvoiceNo,
                i.ReferenceNote,
                i.RentalPayslipNo
            });

            // If underlying data is a large SQL table, specify PrimaryKey and PaginateViaPrimaryKey.
            // This can make SQL execution plans more efficient.
            // For more detailed information, please refer to this discussion: https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "VoucherNo" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(tbl201vouchermasters, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Tbl201VoucherMaster();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Tbl201VoucherMasters.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.VoucherNo });
        }

        [HttpPut]
        public async Task<IActionResult> Put(string key, string values) {
            var model = await _context.Tbl201VoucherMasters.FirstOrDefaultAsync(item => item.VoucherNo == key);
            if(model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(string key) {
            var model = await _context.Tbl201VoucherMasters.FirstOrDefaultAsync(item => item.VoucherNo == key);

            _context.Tbl201VoucherMasters.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(Tbl201VoucherMaster model, IDictionary values) {
            string VOUCHER_NO = nameof(Tbl201VoucherMaster.VoucherNo);
            string VOUCHER_DATE = nameof(Tbl201VoucherMaster.VoucherDate);
            string VOUCHER_REF_NO = nameof(Tbl201VoucherMaster.VoucherRefNo);
            string VOUCHER_NARRATION = nameof(Tbl201VoucherMaster.VoucherNarration);
            string VOUCHER_ENTERED_BY = nameof(Tbl201VoucherMaster.VoucherEnteredBy);
            string VOUCHER_ENTERED_ON = nameof(Tbl201VoucherMaster.VoucherEnteredOn);
            string VOUCHER_VERIFIED_BY = nameof(Tbl201VoucherMaster.VoucherVerifiedBy);
            string VOUCHER_VERIFIED_ON = nameof(Tbl201VoucherMaster.VoucherVerifiedOn);
            string IS_VERIFIED = nameof(Tbl201VoucherMaster.IsVerified);
            string VOUCHER_APPROVED_BY = nameof(Tbl201VoucherMaster.VoucherApprovedBy);
            string VOUCHER_APPROVED_ON = nameof(Tbl201VoucherMaster.VoucherApprovedOn);
            string IS_APPROVED = nameof(Tbl201VoucherMaster.IsApproved);
            string VOUCHER_TYPE = nameof(Tbl201VoucherMaster.VoucherType);
            string VOUCHER_EFFECTIVE_DATE = nameof(Tbl201VoucherMaster.VoucherEffectiveDate);
            string INVOICE_SUBMITTED_DATE = nameof(Tbl201VoucherMaster.InvoiceSubmittedDate);
            string INVOICE_DUE_DATE = nameof(Tbl201VoucherMaster.InvoiceDueDate);
            string INVOICE_NO_OF_DAYS = nameof(Tbl201VoucherMaster.InvoiceNoOfDays);
            string USE_SUBMITTED_DATE = nameof(Tbl201VoucherMaster.UseSubmittedDate);
            string SALES_PERSON_CODE = nameof(Tbl201VoucherMaster.SalesPersonCode);
            string BILL_NO = nameof(Tbl201VoucherMaster.BillNo);
            string BILL_DATE = nameof(Tbl201VoucherMaster.BillDate);
            string BILL_PAID_TO = nameof(Tbl201VoucherMaster.BillPaidTo);
            string BILL_REMARKS = nameof(Tbl201VoucherMaster.BillRemarks);
            string VOUCHER_MODIFIED_BY = nameof(Tbl201VoucherMaster.VoucherModifiedBy);
            string VOUCHER_MODIFIED_ON = nameof(Tbl201VoucherMaster.VoucherModifiedOn);
            string AUDIT_VERIFIED_BY = nameof(Tbl201VoucherMaster.AuditVerifiedBy);
            string AUDIT_VERIFIED_ON = nameof(Tbl201VoucherMaster.AuditVerifiedOn);
            string IS_AUDIT_VERIFIED = nameof(Tbl201VoucherMaster.IsAuditVerified);
            string DELIVERY_NOTE_NO = nameof(Tbl201VoucherMaster.DeliveryNoteNo);
            string COGS_INVOICE_NO = nameof(Tbl201VoucherMaster.CogsInvoiceNo);
            string REFERENCE_NOTE = nameof(Tbl201VoucherMaster.ReferenceNote);
            string RENTAL_PAYSLIP_NO = nameof(Tbl201VoucherMaster.RentalPayslipNo);

            if(values.Contains(VOUCHER_NO)) {
                model.VoucherNo = Convert.ToString(values[VOUCHER_NO]);
            }

            if(values.Contains(VOUCHER_DATE)) {
                model.VoucherDate = Convert.ToDateTime(values[VOUCHER_DATE]);
            }

            if(values.Contains(VOUCHER_REF_NO)) {
                model.VoucherRefNo = Convert.ToString(values[VOUCHER_REF_NO]);
            }

            if(values.Contains(VOUCHER_NARRATION)) {
                model.VoucherNarration = Convert.ToString(values[VOUCHER_NARRATION]);
            }

            if(values.Contains(VOUCHER_ENTERED_BY)) {
                model.VoucherEnteredBy = Convert.ToString(values[VOUCHER_ENTERED_BY]);
            }

            if(values.Contains(VOUCHER_ENTERED_ON)) {
                model.VoucherEnteredOn = values[VOUCHER_ENTERED_ON] != null ? Convert.ToDateTime(values[VOUCHER_ENTERED_ON]) : (DateTime?)null;
            }

            if(values.Contains(VOUCHER_VERIFIED_BY)) {
                model.VoucherVerifiedBy = Convert.ToString(values[VOUCHER_VERIFIED_BY]);
            }

            if(values.Contains(VOUCHER_VERIFIED_ON)) {
                model.VoucherVerifiedOn = values[VOUCHER_VERIFIED_ON] != null ? Convert.ToDateTime(values[VOUCHER_VERIFIED_ON]) : (DateTime?)null;
            }

            if(values.Contains(IS_VERIFIED)) {
                model.IsVerified = values[IS_VERIFIED] != null ? Convert.ToBoolean(values[IS_VERIFIED]) : (bool?)null;
            }

            if(values.Contains(VOUCHER_APPROVED_BY)) {
                model.VoucherApprovedBy = Convert.ToString(values[VOUCHER_APPROVED_BY]);
            }

            if(values.Contains(VOUCHER_APPROVED_ON)) {
                model.VoucherApprovedOn = values[VOUCHER_APPROVED_ON] != null ? Convert.ToDateTime(values[VOUCHER_APPROVED_ON]) : (DateTime?)null;
            }

            if(values.Contains(IS_APPROVED)) {
                model.IsApproved = values[IS_APPROVED] != null ? Convert.ToBoolean(values[IS_APPROVED]) : (bool?)null;
            }

            if(values.Contains(VOUCHER_TYPE)) {
                model.VoucherType = Convert.ToString(values[VOUCHER_TYPE]);
            }

            if(values.Contains(VOUCHER_EFFECTIVE_DATE)) {
                model.VoucherEffectiveDate = values[VOUCHER_EFFECTIVE_DATE] != null ? Convert.ToDateTime(values[VOUCHER_EFFECTIVE_DATE]) : (DateTime?)null;
            }

            if(values.Contains(INVOICE_SUBMITTED_DATE)) {
                model.InvoiceSubmittedDate = values[INVOICE_SUBMITTED_DATE] != null ? Convert.ToDateTime(values[INVOICE_SUBMITTED_DATE]) : (DateTime?)null;
            }

            if(values.Contains(INVOICE_DUE_DATE)) {
                model.InvoiceDueDate = values[INVOICE_DUE_DATE] != null ? Convert.ToDateTime(values[INVOICE_DUE_DATE]) : (DateTime?)null;
            }

            if(values.Contains(INVOICE_NO_OF_DAYS)) {
                model.InvoiceNoOfDays = values[INVOICE_NO_OF_DAYS] != null ? Convert.ToInt16(values[INVOICE_NO_OF_DAYS]) : (short?)null;
            }

            if(values.Contains(USE_SUBMITTED_DATE)) {
                model.UseSubmittedDate = values[USE_SUBMITTED_DATE] != null ? Convert.ToBoolean(values[USE_SUBMITTED_DATE]) : (bool?)null;
            }

            if(values.Contains(SALES_PERSON_CODE)) {
                model.SalesPersonCode = Convert.ToString(values[SALES_PERSON_CODE]);
            }

            if(values.Contains(BILL_NO)) {
                model.BillNo = Convert.ToString(values[BILL_NO]);
            }

            if(values.Contains(BILL_DATE)) {
                model.BillDate = values[BILL_DATE] != null ? Convert.ToDateTime(values[BILL_DATE]) : (DateTime?)null;
            }

            if(values.Contains(BILL_PAID_TO)) {
                model.BillPaidTo = Convert.ToString(values[BILL_PAID_TO]);
            }

            if(values.Contains(BILL_REMARKS)) {
                model.BillRemarks = Convert.ToString(values[BILL_REMARKS]);
            }

            if(values.Contains(VOUCHER_MODIFIED_BY)) {
                model.VoucherModifiedBy = Convert.ToString(values[VOUCHER_MODIFIED_BY]);
            }

            if(values.Contains(VOUCHER_MODIFIED_ON)) {
                model.VoucherModifiedOn = values[VOUCHER_MODIFIED_ON] != null ? Convert.ToDateTime(values[VOUCHER_MODIFIED_ON]) : (DateTime?)null;
            }

            if(values.Contains(AUDIT_VERIFIED_BY)) {
                model.AuditVerifiedBy = Convert.ToString(values[AUDIT_VERIFIED_BY]);
            }

            if(values.Contains(AUDIT_VERIFIED_ON)) {
                model.AuditVerifiedOn = values[AUDIT_VERIFIED_ON] != null ? Convert.ToDateTime(values[AUDIT_VERIFIED_ON]) : (DateTime?)null;
            }

            if(values.Contains(IS_AUDIT_VERIFIED)) {
                model.IsAuditVerified = values[IS_AUDIT_VERIFIED] != null ? Convert.ToBoolean(values[IS_AUDIT_VERIFIED]) : (bool?)null;
            }

            if(values.Contains(DELIVERY_NOTE_NO)) {
                model.DeliveryNoteNo = Convert.ToString(values[DELIVERY_NOTE_NO]);
            }

            if(values.Contains(COGS_INVOICE_NO)) {
                model.CogsInvoiceNo = Convert.ToString(values[COGS_INVOICE_NO]);
            }

            if(values.Contains(REFERENCE_NOTE)) {
                model.ReferenceNote = Convert.ToString(values[REFERENCE_NOTE]);
            }

            if(values.Contains(RENTAL_PAYSLIP_NO)) {
                model.RentalPayslipNo = Convert.ToString(values[RENTAL_PAYSLIP_NO]);
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
        [HttpGet]
        public async Task<ActionResult> GetPaymentAccounts(DataSourceLoadOptions loadOptions)
        {
          
            var qryListOfAccountlists = _context.QryCashAndBankAccounts.Where(p => p.AccountGroupId != null).Select(i => new

            {
                i.AccountHead,
                i.AccountGroupId,
                i.AccountGroup,
                i.MasterGroup,
                i.MasterGroupId

            });

            return Json(await DataSourceLoader.LoadAsync(qryListOfAccountlists, loadOptions));
        }

    }
}