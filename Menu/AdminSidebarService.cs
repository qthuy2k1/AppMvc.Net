using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

namespace App.Menu
{
    public class AdminSidebarService
    {
        private readonly IUrlHelper urlHelper;
        public List<SidebarItem> Items { get; set; } = new List<SidebarItem>();


        public AdminSidebarService(IUrlHelperFactory factory, IActionContextAccessor action)
        {
            urlHelper = factory.GetUrlHelper(action.ActionContext);
            // Khoi tao cac muc sidebar

            Items.Add(new SidebarItem() { Type = SidebarItemType.Divider });
            Items.Add(new SidebarItem() { Type = SidebarItemType.Heading, Title = "Quan li chung" });
            Items.Add(new SidebarItem()
            {
                Type = SidebarItemType.NavItem,
                Controller = "DbManage",
                Action = "Index",
                Area = "Database",
                Title = "Quan li database",
                AwesomeIcon = "fas fa-database"
            });
            Items.Add(new SidebarItem()
            {
                Type = SidebarItemType.NavItem,
                Controller = "Contact",
                Action = "Index",
                Area = "Contact",
                Title = "Quan li lien he",
                AwesomeIcon = "far fa-address-card"
            });
            Items.Add(new SidebarItem() { Type = SidebarItemType.Divider });

            Items.Add(new SidebarItem()
            {
                Type = SidebarItemType.NavItem,
                Title = "Phan quyen & thanh vien",
                AwesomeIcon = "far fa-folder",
                collapseID = "role",
                Items = new List<SidebarItem>() {
                    new SidebarItem()
                    {
                        Type = SidebarItemType.NavItem,
                        Controller = "Role",
                        Action = "Index",
                        Area = "Identity",
                        Title = "Cac vai tro (role)"
                    },
                    new SidebarItem()
                    {
                        Type = SidebarItemType.NavItem,
                        Controller = "Role",
                        Action = "Create",
                        Area = "Identity",
                        Title = "Tao role moi"
                    },
                    new SidebarItem()
                    {
                        Type = SidebarItemType.NavItem,
                        Controller = "User",
                        Action = "Index",
                        Area = "Identity",
                        Title = "Danh sach thanh vien"
                    },
                }
            });

            Items.Add(new SidebarItem() { Type = SidebarItemType.Divider });

            Items.Add(new SidebarItem()
            {
                Type = SidebarItemType.NavItem,
                Title = "Quan ly bai viet",
                AwesomeIcon = "far fa-folder",
                collapseID = "blog",
                Items = new List<SidebarItem>() {
                    new SidebarItem()
                    {
                        Type = SidebarItemType.NavItem,
                        Controller = "Category",
                        Action = "Index",
                        Area = "Blog",
                        Title = "Cac chuyen muc"
                    },
                    new SidebarItem()
                    {
                        Type = SidebarItemType.NavItem,
                        Controller = "Category",
                        Action = "Create",
                        Area = "Blog",
                        Title = "Tao chuyen muc"
                    },
                    new SidebarItem()
                    {
                        Type = SidebarItemType.NavItem,
                        Controller = "Post",
                        Action = "Index",
                        Area = "Blog",
                        Title = "Cac bai viet"
                    },
                    new SidebarItem()
                    {
                        Type = SidebarItemType.NavItem,
                        Controller = "Post",
                        Action = "Create",
                        Area = "Blog",
                        Title = "Tao bai viet"
                    },
                }
            });

            Items.Add(new SidebarItem() { Type = SidebarItemType.Divider });

            Items.Add(new SidebarItem()
            {
                Type = SidebarItemType.NavItem,
                Title = "Quan ly san pham",
                AwesomeIcon = "far fa-folder",
                collapseID = "product",
                Items = new List<SidebarItem>() {
                    new SidebarItem()
                    {
                        Type = SidebarItemType.NavItem,
                        Controller = "CategoryProduct",
                        Action = "Index",
                        Area = "Product",
                        Title = "Cac chuyen muc san pham"
                    },
                    new SidebarItem()
                    {
                        Type = SidebarItemType.NavItem,
                        Controller = "CategoryProduct",
                        Action = "Create",
                        Area = "Product",
                        Title = "Tao chuyen muc"
                    },
                    new SidebarItem()
                    {
                        Type = SidebarItemType.NavItem,
                        Controller = "ProductManage",
                        Action = "Index",
                        Area = "Product",
                        Title = "Cac san pham"
                    },
                    new SidebarItem()
                    {
                        Type = SidebarItemType.NavItem,
                        Controller = "ProductManage",
                        Action = "Create",
                        Area = "Product",
                        Title = "Tao san pham"
                    },
                }
            });
        }

        public string RenderHtml()
        {
            var html = new StringBuilder();

            foreach (var item in Items)
            {
                html.Append(item.RenderHtml(urlHelper));
            }

            return html.ToString();
        }


        public void SetActive(string Controller, string Action, string Area)
        {
            foreach (var item in Items)
            {
                if (item.Controller == Controller && item.Action == Action && item.Area == Area)
                {
                    item.IsActive = true;
                    return;
                }
                else
                {
                    if (item.Items != null)
                    {
                        foreach (var childItem in item.Items)
                        {
                            if (childItem.Controller == Controller && childItem.Action == Action && childItem.Area == Area)
                            {
                                childItem.IsActive = true;
                                item.IsActive = true;
                                return;

                            }
                        }
                    }
                }



            }
        }
    }
}