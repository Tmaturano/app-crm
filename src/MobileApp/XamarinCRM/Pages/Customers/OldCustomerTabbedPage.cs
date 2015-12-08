﻿// The MIT License (MIT)
// 
// Copyright (c) 2015 Xamarin
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
using Xamarin.Forms;
using XamarinCRM.ViewModels.Customers;
using XamarinCRM.Models;

namespace XamarinCRM.Pages.Customers
{
    public class OldCustomerTabbedPage : TabbedPage
    {
        public OldCustomerTabbedPage(Account account)
        {
            Title = account.Company;
            // since we're modally presented this tabbed view (because Android doesn't natively support nested tabs),
            // this tool bar item provides a way to get back to the Customers list

            var customerDetailPage = new CustomerDetailPage()
            {
                BindingContext = new CustomerDetailViewModel(account, this) { Navigation = this.Navigation },
                Title = TextResources.Customers_Detail_Tab_Title,
            };
            if (Device.OS == TargetPlatform.iOS)
                customerDetailPage.Icon = new FileImageSource() { File = "CustomersTab" };

            var customerOrdersPage = new CustomerOrdersPage()
            {
                BindingContext = new OrdersViewModel(account) { Navigation = this.Navigation },
                Title = TextResources.Customers_Orders_Tab_Title,
            };
            if (Device.OS == TargetPlatform.iOS)
                customerOrdersPage.Icon = Icon = new FileImageSource() { File = "ProductsTab" };

            var customerSalesPage = new CustomerSalesPage()
            {
                BindingContext = new CustomerSalesViewModel(account) { Navigation = this.Navigation },
                Title = TextResources.Customers_Sales_Tab_Title,
            };
            if (Device.OS == TargetPlatform.iOS)
                customerSalesPage.Icon = Icon = new FileImageSource() { File = "SalesTab" };

            Children.Add(customerDetailPage);
            Children.Add(customerOrdersPage);
            Children.Add(customerSalesPage);
        }
    }
}
