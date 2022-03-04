using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Learning.Databases.Tables
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Personel")]
    public class Person
    {
        public Person()
        {
            this.Id = Guid.NewGuid();

        }

        public Person(int code, string nickname, decimal salary)
        {
            //this.Id = id;
            this.Code = code;
            this.Nickname = nickname;
            this.Salary = salary;
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Schema.Column("Person_ID", Order = 0)]
        public Guid Id { get; set; }

        //[System.ComponentModel.DataAnnotations.Key]
        //[System.ComponentModel.DataAnnotations.Schema.Column("Persin_ID", Order = 1)]
        //public Guid Id1 { get; set; }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Schema.Column("Person_Code", Order = 1)]
        public int Code { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column("Nickname")]
        public string Nickname { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column("Salary_In_Month")]
        public decimal Salary { get; set; }

        public string Display 
        {
            get 
            {
                string Result = string.Format("{0} - {1} : {2}", Code, Nickname, Salary);
                return Result;
            } 
        }


    }
}
