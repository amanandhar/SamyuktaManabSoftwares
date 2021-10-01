using GrocerySupplyManagementApp.Services.Interfaces;
using GrocerySupplyManagementApp.Shared;
using System;
using System.Windows.Forms;

namespace GrocerySupplyManagementApp.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IFiscalYearService _fiscalYearService;
        private readonly ICompanyInfoService _companyInfoService;
        private readonly ITaxService _taxService;
        private readonly IBankService _bankService;
        private readonly IBankTransactionService _bankTransactionService;
        private readonly IItemService _itemService;
        private readonly IPricedItemService _pricedItemService;
        private readonly IMemberService _memberService;
        private readonly ISupplierService _supplierService;
        private readonly IPurchasedItemService _purchasedItemService;
        private readonly ISoldItemService _soldItemService;
        private readonly IUserTransactionService _userTransactionService;
        private readonly IStockService _stockService;
        private readonly IEndOfDayService _endOfDateService;
        private readonly IEmployeeService _employeeService;
        private readonly IReportService _reportService;
        private readonly IUserService _userService;
        private readonly IItemCategoryService _itemCategoryService;
        private readonly IShareMemberService _shareMemberService;

        #region Constructor
        public LoginForm(IFiscalYearService fiscalYearService,
            ICompanyInfoService companyInfoService, ITaxService taxService,
            IBankService bankService, IBankTransactionService bankTransactionService,
            IItemService itemService, IPricedItemService pricedItemService,
            IMemberService memberService, ISupplierService supplierService,
            IPurchasedItemService purchasedItemService, ISoldItemService soldItemService,
            IUserTransactionService userTransactionService, IStockService stockService,
            IEndOfDayService endOfDateService, IEmployeeService employeeService,
            IReportService reportService, IUserService userService,
            IItemCategoryService itemCategoryService, IShareMemberService shareMemberService)
        {
            InitializeComponent();

            _fiscalYearService = fiscalYearService;
            _companyInfoService = companyInfoService;
            _taxService = taxService;
            _bankService = bankService;
            _bankTransactionService = bankTransactionService;
            _itemService = itemService;
            _pricedItemService = pricedItemService;
            _memberService = memberService;
            _supplierService = supplierService;
            _purchasedItemService = purchasedItemService;
            _soldItemService = soldItemService;
            _userTransactionService = userTransactionService;
            _stockService = stockService;
            _endOfDateService = endOfDateService;
            _employeeService = employeeService;
            _reportService = reportService;
            _userService = userService;
            _itemCategoryService = itemCategoryService;
            _shareMemberService = shareMemberService;
        }
        #endregion

        #region Form Load Event
        private void LoginForm_Load(object sender, EventArgs e)
        {
            TxtUsername.Focus();
        }
        #endregion

        #region Radio Button Event
        private void ChkBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            if(ChkBoxShow.Checked == true)
            {
                TxtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                TxtPassword.UseSystemPasswordChar = true;
            }
        }

        #endregion

        #region Button Event
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Textbox Event
        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                Login();
            }
        }

        #endregion

        #region Helper Methods
        private void Login()
        {
            try
            {
                var username = TxtUsername.Text;
                var password = TxtPassword.Text;

                if (string.IsNullOrWhiteSpace(username.Trim()) || string.IsNullOrWhiteSpace(password.Trim()))
                {
                    var error = MessageBox.Show("Username or Password is empty.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (error == DialogResult.OK)
                    {
                        return;
                    }
                }

                var encryptedPassword = Cryptography.Encrypt(password);
                var result = _userService.IsUserExist(username, encryptedPassword);
                if (result)
                {
                    var dashboard = new DashboardForm(username, _fiscalYearService, _companyInfoService, _taxService, _bankService,
                        _bankTransactionService, _itemService, _pricedItemService, _memberService,
                        _supplierService, _purchasedItemService, _soldItemService, _userTransactionService,
                        _stockService, _endOfDateService, _employeeService, _reportService,
                        _userService, _itemCategoryService, _shareMemberService);
                    this.Hide();
                    dashboard.Show();
                }
                else
                {
                    var error = MessageBox.Show("Username or Password is invalid.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (error == DialogResult.OK)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
