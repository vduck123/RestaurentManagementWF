using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RestaurentManagement.utils
{
    internal class Context
    {
        private static Context instance;
        public static Context Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Context();
                }
                return instance;
            }
        }
        
        Random random = new Random();
        
        public void GetFakeStaff(int count)
        {
            List<Account> listAcc = Faker.Instance.FakeAccount(count);
            List<Staff> listStaff = Faker.Instance.FakeStaff(count, listAcc);
            List<Salary> listSalary = Faker.Instance.FakeSalary(count, listStaff);
            int rsAcc = 0;
            int rsStaff = 0;
            int rsSalary = 0;
            foreach (Account acc in listAcc)
            {
                rsAcc = AccountController.Instance.InsertAccount(acc);
            }

            if(rsAcc > 0)
            {
                foreach (Staff staff in listStaff)
                {
                    rsStaff = StaffController.Instance.InsertStaff(staff);
                }
            }

            if(rsStaff > 0)
            {
                foreach (Salary salary in listSalary)
                {
                    rsSalary = SalaryController.Instance.InsertSalary(salary);
                }
            }
        }

        public void GetFakeBillImport(int count)
        {
            List<BillImport> listBill = Faker.Instance.FakeBillImport(count);
            
            foreach(BillImport bill in listBill)
            {
                int rsBill = BillImportController.Instance.InsertBillImport(bill);
                if(rsBill > 0)
                {
                    int num = random.Next(3, 6);
                    List<BillImportInfo> listBillInfo = Faker.Instance.FakeBillImportInfo(num, bill.ID);
                    foreach (BillImportInfo billInfo in listBillInfo)
                    {
                        BillImportInfoController.Instance.InsertBillImportInfor(billInfo);
                    }
                }  
            }
        }

        public void GetFakeBillSale(int count)
        {
            List<BillSale> listBill = Faker.Instance.FakeBillSale(count);

            foreach (BillSale bill in listBill)
            {
                int rsBill = BillSaleController.Instance.InsertBillSale(bill);
                if (rsBill > 0)
                {
                    int num = random.Next(3, 6);
                    List<BillSaleInfo> listBillInfo = Faker.Instance.FakeBillSaleInfo(num, bill.Id);
                    foreach (BillSaleInfo billInfo in listBillInfo)
                    {
                        BillSaleInfoController.Instance.InsertBillSaleInfo(billInfo);
                    }
                }
            }
        }

        public void GetFakeSupplier(int count)
        {
            List<Supplier> listSupplier = Faker.Instance.FakerSupplier(count);
            foreach (Supplier supp in listSupplier)
            {
                SupplierController.Instance.InsertSupplier(supp);
            }
        }

    }
}
