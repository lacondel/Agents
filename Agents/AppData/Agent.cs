//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Agents.AppData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Agent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agent()
        {
            this.AgentPriorityHistory = new HashSet<AgentPriorityHistory>();
            this.ProductSale = new HashSet<ProductSale>();
            this.Shop = new HashSet<Shop>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public int AgentTypeID { get; set; }
        public string Address { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string DirectorName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }
        public int Priority { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual AgentType AgentType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgentPriorityHistory> AgentPriorityHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductSale> ProductSale { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shop> Shop { get; set; }

        public string AddLogo
        {
            get
            {
                if (String.IsNullOrEmpty(Logo) || String.IsNullOrWhiteSpace(Logo))
                {
                    return "/agents/picture.png";
                }
                else
                {
                    return "/" + Logo;
                }
            }
        }
        public string AddType
        {
            get
            {
                var type = AppConnect.model0db.AgentType.FirstOrDefault(t => t.ID == AgentTypeID);

                if (type != null)
                {
                    return type.Title;
                }
                else
                {
                    return "Тип не найден";
                }
            }
        }
        public string AddSaleCount 
        {
            get
            {
                var sc = AppConnect.model0db.ProductSale.FirstOrDefault(s => s.AgentID == ID);

                if (sc != null)
                {
                    return sc.ProductCount.ToString();
                }
                else
                {
                    return "0";
                }
            }
        }
    }
}
