using RestaurentManagement.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurentManagement.Controllers;

namespace RestaurentManagement.utils
{
    internal class Faker
    {
        private static Faker instance;
        public static Faker Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Faker();
                }   
                return instance;
            }
        }



        public Random random = new Random();
       
        public List<Supplier> FakerSupplier(int count)
        {
            string idSupp = $"NCC00{SupplierController.Instance.GetOrderNumInList()}";
            var supplierFaker = new Faker<Supplier>("vi")
                .StrictMode(true)
                .RuleFor(o => o.ID, f => idSupp)
                .RuleFor(o => o.Name, f => $"{f.Name.FirstName()}{f.Random.String2(3)}")
                .RuleFor(o => o.Address, f => f.Address.City())
                .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber("09########"))
                .RuleFor(o => o.Note, f => f.Random.String2(10));
            var supplierFake = supplierFaker.Generate(count);
            return supplierFake;
        }

        public List<Account> FakeAccount(int count)
        {
            int idAcc = AccountController.Instance.GetOrderNumInList() + 1;
            string role = "Nhân viên";
            var accFaker = new Faker<Account>("vi")
                .StrictMode(true)
                .RuleFor(o => o.ID, f => $"ACC00{idAcc++.ToString()}")
                .RuleFor(o => o.User, f => f.Internet.Email())
                .RuleFor(o => o.Password, f => f.Random.Number(1, 10).ToString())
                .RuleFor(o => o.Role, f => role);
            var accFake = accFaker.Generate(count);
            return accFake;
        }

        public List<Staff> FakeStaff(int quantity, List<Account> accounts)
        {
            string idStaff = $"NV00{StaffController.Instance.GetOrderNumInList() + 1}";
            string[] gender = new string[] { "Nam", "Nữ" };
            var userFaker = new Faker<Staff>("vi")
                .StrictMode(true)
                .RuleFor(o => o.ID, f => idStaff)
                .RuleFor(o => o.Name, f => $"{f.Name.LastName()} {f.Name.FirstName()}")
                .RuleFor(o => o.Gender, f => f.PickRandom(gender))
                .RuleFor(o => o.Birth, f => f.Date.Between(new DateTime(1995, 1, 1), new DateTime(2004, 12, 31)))
                .RuleFor(o => o.Address, f => f.Address.City())
                .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber($"09########"))
                .RuleFor(o => o.Acc_ID, (f, u) => accounts[f.IndexFaker].ID);
            var userFake = userFaker.Generate(quantity);
            return userFake;
        }
        public List<Salary> FakeSalary(int quantity, List<Staff> users)
        {
         
            string idSalary = $"BL00{SalaryController.Instance.GetOrderNumInList() + 1}";
            var salary = new Faker<Salary>("vi")
                .StrictMode(true)
                .RuleFor(o => o.ID, f => idSalary)
                .RuleFor(o => o.Month, f => f.Date.Between(new DateTime(2023, 1, 1), new DateTime(2024, 5, 1)))
                .RuleFor(o => o.salaryBasic, f => (random.Next(40, 50) / 10) * 1000000)
                .RuleFor(o => o.hsl, f => (random.Next(150, 301) / 100.0))
                .RuleFor(o => o.salaryHour, f => (random.Next(20, 30) / 10) * 10000)
                .RuleFor(o => o.numHour, f => f.Random.Number(200, 300))
                .RuleFor(o => o.Bonus, f => (f.Random.Number(1, 5)) * 100000)
                .RuleFor(o => o.Fine, f => (f.Random.Number(1, 5)) * 100000)
                .RuleFor(o => o.Total, (f, o) => (o.salaryBasic * o.hsl) + (o.salaryHour * o.numHour) + o.Bonus + o.Fine)
                .RuleFor(o => o.staffID, f => users[f.IndexFaker].ID);
            var salaryFaker = salary.Generate(quantity);
            return salaryFaker;
        }

        public List<BillImport> FakeBillImport(int count)
        {
            string[] idSuppliers = new string[] { "NCC000", "NCC001", "NCC002", "NCC003", "NCC004", "NCC005", "NCC006", "NCC007", "NCC008", "NCC009" };
            string[] idStaffs = new string[] { "NV0000", "NV0001", "NV0002", "NV0003", "NV0004", "NV0005", "NV0006", "NV0007", "NV0008", "NV0009" };
            int orderBillImport = BillImportController.Instance.GetOrderNumInList();
            int total = 0;
            var billImport = new Faker<BillImport>()
                .StrictMode(true)
                .RuleFor(o => o.ID, f => $"HDN00{orderBillImport++}")
                .RuleFor(o => o.DayCreated, f => f.Date.Between(new DateTime(2023, 01, 01), new DateTime(2024, 6, 1)))
                .RuleFor(o => o.SupplierID, f => f.PickRandom(idSuppliers))
                .RuleFor(o => o.StaffID, f => f.PickRandom(idStaffs))
                .RuleFor(o => o.TotalMoney, f => total);
            var billImportFaker = billImport.Generate(10);
            return billImportFaker;
        }

        public List<BillImportInfo> FakeBillImportInfo(int count, string idBill)
        {
            string[] idMaterials = new string[] { "NL0001", "NL0002", "NL0003", "NL0004", "NL0005", "NL0006", "NL0007", "NL0008", "NL0009", "NL00010", "NL00011", "NL00012", "NL00013", "NL00014", "NL00015" };
            int orderBillImportInfo = BillImportInfoController.Instance.GetOrderNumBillImportInfo();
            int totalBill = 0;
            var billImportInfo = new Faker<BillImportInfo>()
                .StrictMode(true)
                .RuleFor(o => o.ID, f => $"CTHDN0{orderBillImportInfo++}")
                .RuleFor(o => o.ItemID, f => f.PickRandom(idMaterials))
                .RuleFor(o => o.Price, f => (f.Random.Number(10, 50) / 10) * 10000)
                .RuleFor(o => o.Quantity, f => f.Random.Number(5, 20))
                .RuleFor(o => o.TotalMoney, (f, u) => u.Price * u.Quantity)
                .RuleFor(o => o.Unit, (f,u) => WarehouseController.Instance.GetUnitMaterialById(u.ItemID))
                .RuleFor(o => o.BillID, f => idBill);
            var billImportInfoFaker = billImportInfo.Generate(count);
            billImportInfoFaker.ForEach(o =>
            {
                totalBill += o.TotalMoney;
            });
            BillImportController.Instance.UpdateTotalBillByID(idBill, totalBill);
            return billImportInfoFaker;
        }

        public List<BillSale> FakeBillSale(int count)
        {
            string[] idTables = new string[] { "BA0001", "BA0002", "BA0003", "BA0004", "BA0005", "BA0006", "BA0007", "BA0008", "BA0009", "BA00010" };
            string[] idStaffs = new string[] { "NV0000", "NV0001", "NV0002", "NV0003", "NV0004", "NV0005", "NV0006", "NV0007", "NV0008", "NV0009" };
            string[] idVouchers = new string[] { "PGG001"};
            int orderBillSale = BillSaleController.Instance.GetNumOrderBill();
            int total = 0;
            var billSale = new Faker<BillSale>("vi")
                .StrictMode(true)
                .RuleFor(o => o.Id, f => $"HDB00{orderBillSale++}")
                .RuleFor(o => o.dayIn, f => f.Date.Between(new DateTime(2023, 01, 01), new DateTime(2024, 6, 1)))
                .RuleFor(o => o.dayOut, f => f.Date.Between(new DateTime(2023, 01, 01), new DateTime(2024, 6, 1)).AddHours(f.Random.Number(2, 4)))
                .RuleFor(o => o.staffID, f => f.PickRandom(idStaffs))
                .RuleFor(o => o.voucherId, f => f.PickRandom(idVouchers))
                .RuleFor(o => o.Customer, f => $"{f.Name.LastName()} {f.Name.FirstName()}")
                .RuleFor(o => o.tableID, f => f.PickRandom(idTables))
                .RuleFor(o => o.totalMoney, f => total);
            var billSaleFaker = billSale.Generate(count);
            return billSaleFaker;
        }

        public List<BillSaleInfo> FakeBillSaleInfo(int count, string boSaleId)
        {
            string[] idFoods = new string[] { "F00001", "F00002", "F00003", "F00004", "F00005", "F00006", "F00007", "F00008", "F00009", "F000010"};
            int orderBillImportInfo = BillSaleInfoController.Instance.GetNumOrderBillInfo();
            int totalBill = 0;       
            var billSaleInfo = new Faker<BillSaleInfo>("vi")
                .StrictMode(true)
                .RuleFor(o => o.ID, f => $"CTHDN0{orderBillImportInfo++}")
                .RuleFor(o => o.foodId, f => f.PickRandom(idFoods))
                .RuleFor(o => o.Quantity, f => f.Random.Number(1, 4))
                .RuleFor(o => o.foodPrice, (f,u) => FoodController.Instance.GetPriceFoodById(u.foodId))
                .RuleFor(o => o.Total, (f, u) => u.foodPrice * u.Quantity)
                .RuleFor(o => o.boSaleId, f => boSaleId);
            var billSaleInfoFaker = billSaleInfo.Generate(count);
            billSaleInfoFaker.ForEach(o =>
            {
                totalBill += o.Total;
            });
            BillSaleController.Instance.UpdateTotalBillByID(boSaleId, totalBill);
            return billSaleInfoFaker;
        }




    }
}
