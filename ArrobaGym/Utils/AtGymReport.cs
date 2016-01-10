using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrobaGym.Utils
{
    public class AtGymReport
    {
        public enum AtGymReportType
        {
            PresentDay,
            PresentMonth,
            FiscalMonth,
            CurrentYearQuarter,
            CurrentYear
        }

        private DAO.Repository<Models.Cliente> ClienteDAO = new DAO.Repository<Models.Cliente>();
        private DAO.Repository<Models.Registro_Productos> RegistroProductosDAO = new DAO.Repository<Models.Registro_Productos>();
        private DAO.Repository<Models.Productos> ProductosDAO = new DAO.Repository<Models.Productos>();
        private DAO.Repository<Models.Calentamientos> CalentamientosDAO = new DAO.Repository<Models.Calentamientos>();
        private DAO.Repository<Models.Seguimiento> SeguimientoDAO = new DAO.Repository<Models.Seguimiento>();
        private DAO.Repository<Models.Personal> PersonalDAO = new DAO.Repository<Models.Personal>();
        private DAO.Repository<Models.Gastos> GastosDAO = new DAO.Repository<Models.Gastos>();


        public string ReportType { get { return ReportType; } set { ReportType = value; } }
        public decimal MembershipIncome { get { return MembershipIncome; } set { MembershipIncome = value; } }
        public decimal WarmupIncome { get { return WarmupIncome; } set { WarmupIncome = value; } }
        public decimal SalesIncome { get { return SalesIncome; } set { SalesIncome = value; } }
        public decimal EmployeesPayment { get { return EmployeesPayment; } set { EmployeesPayment = value; } }
        public decimal Rental { get { return Rental; } set { Rental = value; } }
        public decimal ElectricityCosts { get { return ElectricityCosts; } set { ElectricityCosts = value; } }
        public decimal Mantainment { get { return Mantainment; } set { Mantainment = value; } }
        public decimal Merchandise { get { return Merchandise; } set { Merchandise = value; } }
        public decimal NetBalance { get { return NetBalance; }  set { NetBalance = value; } }

        public AtGymReport(AtGymReportType type)
        {
            switch (type)
            {
                case AtGymReportType.PresentDay:
                    {
                        ReportType = "Día de hoy";
                        InitializeFields(
                            c => c.Ultimo_Pago == DateTime.Today,
                            s => s.Fecha == DateTime.Today,
                            ca => ca.FechaYHora == DateTime.Today,
                            rp => rp.FechaYHora == DateTime.Today,
                            p => true,
                            g => g.Fecha == DateTime.Today);
                        break;
                    }
                case AtGymReportType.PresentMonth:
                    {
                        ReportType = "Mes en Curso";
                        InitializeFields(
                            c => c.Ultimo_Pago.Value.Month == DateTime.Now.Month,
                            s => s.Fecha.Month == DateTime.Now.Month,
                            ca => ca.FechaYHora.Value.Month == DateTime.Now.Month,
                            rp => rp.FechaYHora.Value.Month == DateTime.Now.Month,
                            p => true,
                            g => g.Fecha.Month == DateTime.Now.Month);
                        break;
                    }
                case AtGymReportType.FiscalMonth:
                    {
                        ReportType = "Ultimos 30 días";
                        InitializeFields(
                            c => DateTime.Now.DayOfYear - c.Ultimo_Pago.Value.DayOfYear <= 30,
                            s => DateTime.Now.DayOfYear - s.Fecha.DayOfYear <= 30,
                            ca => DateTime.Now.DayOfYear - ca.FechaYHora.Value.DayOfYear <= 30,
                            rp => DateTime.Now.DayOfYear - rp.FechaYHora.Value.DayOfYear <= 30,
                            p => true,
                            g => DateTime.Now.DayOfYear - g.Fecha.DayOfYear <= 30);
                        break;
                    }
                case AtGymReportType.CurrentYearQuarter:
                    {
                        ReportType = "Cuatrimestre Actual";
                        InitializeFields(
                            c => DateTime.Now.Month - c.Ultimo_Pago.Value.Month <= 4,
                            s => DateTime.Now.Month - s.Fecha.Month <= 4,
                            ca => DateTime.Now.Month - ca.FechaYHora.Value.Month <= 4,
                            rp => DateTime.Now.Month - rp.FechaYHora.Value.Month <= 4,
                            p => true,
                            g => DateTime.Now.Month - g.Fecha.Month <= 4);
                        break;
                    }
                case AtGymReportType.CurrentYear:
                    {
                        ReportType = "Año Actual";
                        InitializeFields(
                            c => c.Ultimo_Pago.Value.Year == DateTime.Now.Year,
                            s => s.Fecha.Year == DateTime.Now.Year,
                            ca => ca.FechaYHora.Value.Year == DateTime.Now.Year,
                            rp => rp.FechaYHora.Value.Year == DateTime.Now.Year,
                            p => true,
                            g => g.Fecha.Year == DateTime.Now.Month);
                        break;
                    }
            }
        }

        private void InitializeFields(
            Func<Models.Cliente, bool> exp1,
            Func<Models.Seguimiento, bool> exp2,
            Func<Models.Calentamientos, bool> exp3,
            Func<Models.Registro_Productos, bool> exp4,
            Func<Models.Personal, bool> exp5,
            Func<Models.Gastos, bool> exp6)
        {
            MembershipIncome = (decimal)(ClienteDAO.FindAll(exp1).Sum( c => c.Saldo) + SeguimientoDAO.FindAll(exp2).Sum(s => s.Saldo_Mes));
            WarmupIncome = (decimal)CalentamientosDAO.FindAll(exp3).Sum(c => c.Cuota);
            SalesIncome = (decimal)RegistroProductosDAO.FindAll(exp4).Sum(p => p.Cantidad_Vendida*ProductosDAO.SelectSingle(p2 => p2.Id == p.Id_Producto).Precio);
            EmployeesPayment = (decimal)PersonalDAO.FindAll(exp5).Sum(p => p.Salario);
            Rental = (decimal)GastosDAO.FindAll(exp6).Single(nombre_gasto => nombre_gasto.Id == 0).Monto;
            ElectricityCosts = (decimal)GastosDAO.FindAll(exp6).Single(nombre_gasto => nombre_gasto.Id == 0).Monto;
            Mantainment = (decimal)GastosDAO.FindAll(exp6).Single(nombre_gasto => nombre_gasto.Id == 0).Monto;
            Merchandise = (decimal)GastosDAO.FindAll(exp6).Single(nombre_gasto => nombre_gasto.Id == 0).Monto;
            NetBalance = (decimal)GastosDAO.FindAll(exp6).Single(nombre_gasto => nombre_gasto.Id == 0).Monto;
        }
    }
}

