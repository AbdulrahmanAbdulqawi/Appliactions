// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("", "CA1014", Justification = "<NikGitStats>", Scope = "module")]
[assembly: SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "<disposable>", Scope = "type", Target = "~T:MyTobaccoShop.WPFClient.MainLogic")]
[assembly: SuppressMessage("Usage", "CA2234:Pass system uri objects instead of strings", Justification = "<Pass system uri objects instead of strings>", Scope = "member", Target = "~M:MyTobaccoShop.WPFClient.MainLogic.ApiGetUsers~System.Collections.Generic.IList{MyTobaccoShop.WPFClient.UserVM}")]
[assembly: SuppressMessage("Usage", "CA2234:Pass system uri objects instead of strings", Justification = "<Pass system uri objects instead of strings>", Scope = "member", Target = "~M:MyTobaccoShop.WPFClient.MainLogic.ApiDelUser(MyTobaccoShop.WPFClient.UserVM)")]
[assembly: SuppressMessage("Usage", "CA2234:Pass system uri objects instead of strings", Justification = "<Pass system uri objects instead of strings>", Scope = "member", Target = "~M:MyTobaccoShop.WPFClient.MainLogic.ApiEditUser(MyTobaccoShop.WPFClient.UserVM,System.Boolean)~System.Boolean")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<Dispose>", Scope = "member", Target = "~M:MyTobaccoShop.WPFClient.MainLogic.ApiEditUser(MyTobaccoShop.WPFClient.UserVM,System.Boolean)~System.Boolean")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<read>", Scope = "member", Target = "~P:MyTobaccoShop.WPFClient.MainVM.AllUsers")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<static>", Scope = "member", Target = "~M:MyTobaccoShop.WPFClient.MainLogic.SendMessage(System.Boolean)")]
