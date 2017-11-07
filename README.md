# Ajax-AutoComplete-Text
AutoComplete With DataBase and AjaxControlToolkit - This is a very simple code which makes an Auto Complete Combo with database.
This is very simple code which makes an Auto Complete Combo with database. 
It's useful. First of all, you do not have to know about Ajax functions, just download the AJAX Control Toolkit on CodePlex and follow me, then enjoy. Besides when there are many rows, you can type part of the word in the text box, then it can offer all of the words which are similar to it. 
Background: What is Ajaxcontroltoolkit?
The ASP.NET AJAX Control Toolkit is an open-source project built on top of the Microsoft ASP.NET AJAX framework and contains more than 30 controls that enable you to easily create rich, Interactive web pages. If you want to know more about it, visit this link.
Using the Code
It the first step, you must download AjaxControlToolkit from here for .NET 3.5 OR here for .NET 4.0.
You must go here and download ajaxcontroltoolkit, then Copy ajaxcontroltoolkit and paste them to Bin Folder, right click on solution, choose Add Reference, in the browse tab double click on the Bin Folder, and double click on ajaxcontroltoolkit, then on the Build Menu > click Rebuild.
DataBase
New Query
Hide   Copy Code
CREATE TABLE [dbo].[tblCustomer](
	    [CompanyName] [nvarchar](500) NULL,
	    [ID] [int] IDENTITY(1,1) NOT NULL
        ) ON [PRIMARY]

insert into dbo.tblCustomer(CompanyName) values('calemard')
insert into dbo.tblCustomer(CompanyName) values('dantherm')
insert into dbo.tblCustomer(CompanyName) values('dango dienenthal')
insert into dbo.tblCustomer(CompanyName) values('daewoo')
insert into dbo.tblCustomer(CompanyName) values('daim engineering')
Visual Studio 2008 - .NET 3.5: Create Web Site and name it AutoComplete, create Web Form and name it AutoComplete.aspx, in HTML view, write this code.
But there is a little difference between C# and VB in this section.
This code in the bottom is for C# coders. 
If you are a VB coder, please modify 2 sections in page tag 
One: correct language=VB 
Two: correct CodeFile="AutoComplete.aspx.vb" 
