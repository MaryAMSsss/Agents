using DemoVar8wifArtem.DataB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;

namespace DemoVar8wifArtem.Models
{
    public partial class Agent
    {
        string startPath = @"C:\Users\razum\Desktop\Предметы\DemoVar8wifArtem\DemoVar8wifArtem\Res";

        public Agent()
        {
            ProductSales = new HashSet<ProductSale>();
        }
        public int Id { get; set; }
        public string? AgentName { get; set; }
        public int? AgentTypeId { get; set; }
        public string AgentTypeDescription { get {
                
                List<AgentType> agents = AgentTypeDB.GetAgentType();
                AgentType agent = agents.FirstOrDefault(i => i.Id == AgentTypeId);
                if( agent == null)
                {
                    return string.Empty;
                }
                return agent.Description;                
            } }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Logo { get; set; }
        public string FullPath { get {
                if (Logo == "нет")
                {
                    return startPath + @"\picture.png";
                }
                else
                {
                    return startPath + Logo;
                }
            } }
        public string? Address { get; set; }
        public int? Priority { get; set; }
        public string? DirectorName { get; set; }
        public string? Inn { get; set; }
        public string? Kpp { get; set; }
        public int ProductSalesOnYear { get {
                DateTime now = DateTime.Now;
                DateTime yearAgo = now.AddYears(-5);
                int sum = 0;
                List<ProductSale> prSale = ProductSaleDB.GetProductSale();
                foreach(ProductSale item in prSale)
                {
                    if(item.AgentId == Id && item.Date > yearAgo)
                    {
                        sum += item.CountOfProduct??0;
                    }
                }
                return sum;
            } }       
        public string Discount { get
            {
                string discont ="0%";
                if(ProductSalesOnYear >0 & ProductSalesOnYear <=10000)
                {
                    discont = "0%";
                }
                if(ProductSalesOnYear>10000 & ProductSalesOnYear <= 50000)
                {
                    discont = "5%";
                }
                if(ProductSalesOnYear>50000 & ProductSalesOnYear <= 150000)
                {
                    discont = "10%";
                }
                return discont;
            } }
        public Agent(string name, int type, string email, 
            string phone, string logo, string address, int priority,
            string director, string inn, string kpp)
        {
            AgentName = name;
            AgentTypeId = type;
            Email = email;
            Phone = phone;
            Logo = logo;
            Address = address;
            Priority = priority;
            DirectorName = director;
            Inn = inn;
            Kpp = kpp;
        }
        public virtual AgentType? AgentType { get; set; }
        public virtual ICollection<ProductSale> ProductSales { get; set; }
    }
}
