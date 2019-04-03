using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Business.Infrastructure;
using DataModels.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IproductBusiness _productBusiness { get; set; }

        public ProductController()
        {

        }

        //public ProductController(IproductBusiness productBusiness)
        //{
        //    this._productBusiness = productBusiness;
        //}

        //[HttpGet]
        //[Route("getallproducts")]
        //public async Task<IActionResult> GetAllProductsAsync()
        //{
        //    var result = await _productBusiness.GetAllProduct();

        //    if (!result.Any()) return NotFound();

        //    return Ok(result);
        //}
        [HttpGet]
        [Route("getemployeebyid")]
        public Employee Get(int id)
        {
          
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=DESKTOP-PTAUQID;Database=NorthwindTraders;User ID=sa;Password=shezar@123;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from Employees where EmployeeId=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Employee emp = null;
            while (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(reader.GetValue(0));
                emp.Name = reader.GetValue(2).ToString();
                emp.Title = reader.GetValue(3).ToString();
            }

            myConnection.Close();
            return emp;

        }


        [HttpGet]
        [Route("getallemployee")]
        public List<Employee> GetAllEmployee()
        {
            List<Employee> employees = new List<Employee>();
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=DESKTOP-PTAUQID;Database=NorthwindTraders;User ID=sa;Password=shezar@123;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select top(10) * from Employees";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();

            if (reader.HasRows)
            {
                Employee emp = null;

                while (reader.Read())
                {
                    emp = new Employee();
                    emp.EmployeeId = Convert.ToInt32(reader.GetValue(0));
                    emp.Name = reader.GetValue(2).ToString();
                    emp.Title = reader.GetValue(3).ToString();
                    employees.Add(emp);
                }
            }

            myConnection.Close();

            return employees;
        }
    }

}