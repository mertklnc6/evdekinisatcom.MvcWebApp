﻿using System.Collections.Generic;
using System.Drawing;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;

@model List<CategoryViewModel>

<div class= "category-sidebar" >
    < h4 > Kategoriler </ h4 >
    < ul class= "category-menu" >
        @foreach(var category in Model.Where(c => c.ParentCategoryId == null))
        {
            < li >
                < a href = "@Url.Action("Index", "Products", new { categoryId = category.Id })" > @category.Name </ a >
                @if(category.subCategories != null && category.subCategories.Count > 0)
                {
                    < ul >
                        @foreach(var subCategory in category.subCategories)
                        {
                            < li >< a href = "@Url.Action("Index", "Products", new { categoryId = subCategory.Id })" > @subCategory.Name </ a ></ li >
                        }
                    </ ul >
                }
            </ li >
        }
    </ ul >
</ div >

< style >
    .category - sidebar {
    background - color: #f7f7f7;
        padding: 15px;
    border - radius: 5px;
    box - shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

        .category - sidebar h4 {
            margin-bottom: 15px;
font - weight: bold;
        }

    .category - menu {
    list - style - type: none;
padding: 0;
}

        .category - menu > li {
    margin - bottom: 10px;
}

        .category - menu a {
            text-decoration: none;
color: #333;
            font - weight: 500;
transition: color 0.3s;
        }

            .category - menu a: hover {
color: #007BFF;
            }

        .category - menu > li > ul {
display: none;
    list - style - type: none;
    padding - left: 20px;
}

        .category - menu > li:hover > ul {
display: block;
}

        .category - menu > li > ul > li > a {
    font - weight: 400;
}
</ style >


