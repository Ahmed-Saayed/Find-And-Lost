# Find-And-Lost

<h3>🎯This project Api is a Find-And-Lost  System API built using ASP.NET Core. The API provides endpoints to manage various entities such as Users,Lost and Find Phones, Lost and Find Personal Cards. It also includes JWT authentication for user registration and login.</h3>

![Image](https://github.com/user-attachments/assets/1202055e-55e6-47a6-91a3-c28d27aadd3c)

![Image](https://github.com/user-attachments/assets/b83ea5ce-6c44-4123-8d12-324c5cf59f17)

<h2>💥Features</h2>
<ul>
  <li>🔐JWT authentication system for user registration and login.</li>
  <li>🔑Hashed Password Encryption for users.</li>
  <li>CRUD operations for Lost and Find,Phones and Cards,</li>
  <li>Methods authorized by manager, and the user can add Lost-find phoes and cards.</li>
  <li>Repository Pattern for stucture and cleaning code with reduce duplication.</li>
  <li>One-Many from users to lost-find phones and cards.</li>
</ul>

<h2>📌Endpoints</h2>

 <h4>Its guaranted that when you run , the app will add initialy manager with email = "Manager1@gmail" , and password = "123456789"</h4>
 
<h3>Auth</h3>
<ul>
  <li><code>Post /api/Auth/Register</code>: register</li>    
  <li><code>Post /api/Auth/Login</code>: login</li>
  <li><code>Post /api/Auth/AddManager</code>: Add Managers</li>
</ul>

<h3>Checking_For_Items</h3>
<ul>
  <li><code>Get /api/Checking_For_Items/Get Cards by Email</code>:Get all founded cards that registered in table lost cards of {email}</li>    
  <li><code>Get /api/Checking_For_Items/Get Phones by Email</code>:Get all founded phones that registered in table lost phone of {email}</li>
</ul>

<h3>Find_Card</h3>
<ul>
  <li><code>Get /api/Find_Card/Get All Founded Cards</code>: Get all founded Cards</li>
  <li><code>Post /api/Find_Card/Add find Card</code>: Add founded Card</li>
  <li><code>Put /api/Find_Card/Update Find Card</code>: Update founded card</li>
  <li><code>Delete /api/Find_Card/Delete find Card</code>: delete founded card</li>
</ul>

<h3>Find_Phone</h3>
<ul>
  <li><code>Get/api/Find_Phone/Get All Founded Phones</code>: Get all founded phones</li>
  <li><code>Post /api/Find_Phone/Add find phone</code>: Add founded Phone</li>
  <li><code>Put /api/Find_Phone/Update found phone</code>: Update founded phone</li>
  <li><code>Delete /api/Find_Phone/Delete find phone</code>: delete founded phone</li>
</ul>

<h3>Lost_Phone</h3>
<ul>
  <li><code>Get /api/Lost_Phone/Get All Losted Phones</code>: Get all losted phones</li>
  <li><code>Get /api/Lost_Phone/Get Losted Phones By Email</code>: Get all losted phones by email</li>
  <li><code>Post /api/Lost_Phone/Add Losted Phone</code>: Add lost phone</li>
  <li><code>Put /api/Lost_Phone/Update Losted Phone</code>: Update lost phone</li>
  <li><code>Delete /api/Lost_Phone/Delete Lost Phone</code>: delete lost phone</li>
</ul>

<h3>Lost_Card</h3>
<ul>
  <li><code>Get /api/Lost_Card/Get All Losted Cards</code>: Get all losted cards</li>
  <li><code>Get /api/Lost_Card/Get Losted Cards By Email</code>: Get all losted cards by email</li>
  <li><code>Post /api/Lost_Card/Add Losted Card</code>: Add lost card</li>
  <li><code>Put /api/Lost_Card/Update Losted Card</code>: Update lost card</li>
  <li><code>Delete /api/Lost_Card/Delete Lost Card</code>: delete lost card</li>
</ul>

<h2>🔐Authentication</h2>
This API uses JWT authentication for user registration and login. Users need to register and login to obtain a refresh token, which they will use to access the various entity endpoints.

<h2>🥇Technologies </h2>
<ul>
  <li>ASP.NET Core for building the API.</li>
  <li>AutoMapper for mapping between entity models and DTOs.</li>
  <li>JWT authentication for user security.</li>
  <li>Refresh Token</li>
  <li>Entity Framework Core for database operations.</li>
  <li>SQL Server.</li>
</ul>

<h2>🌹How to Run the Project</h2>
<ol>
  <li>Clone this repository to your local machine.</li>
  <li>Open the project in your preferred IDE.</li>
  <li>Add migration <code>Add-Migration init</code></li>
  <li>Update Data base <code>Update-Database</code></li>
  <li>Run the project</li>
  <li>Finally do not Forget to Login as a manager to access any thing with (email = "Manager1@gmail" , and password = "123456789") , to be Authorized to access Methods</li>
</ol>


