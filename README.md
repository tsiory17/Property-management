# 

# Manage Property Web Application 

Technology**<u>:</u>** \#C , ASP.net Core MVC , MSQL , Visual Studio

## Introduction

**Property Management Application** is a simple and effective platform
that helps property owners, managers, and clients work together easily.
It brings all the key features they need into one place, making property
management smooth and convenient.

**Description**

The application opens up on a page which states the mission of the
website

<img src="./media/image1.png"
style="width:5.99306in;height:5.08333in" />

Once the user clicks the button get started, it will redirect them to
the login page

<img src="./media/image2.png"
style="width:4.08333in;height:4.31944in" />

The login page allows the user to choose which their role. The dashboard
and functionalities will be different depending on their specific roles

<img src="./media/image3.png" style="width:3.60417in;height:3.3125in" />

**<u>Different types of Roles :</u>**

### 1-Owner

**<u>Description</u>**

An **Owner** in the application is responsible for overseeing their
properties. They can manage **Managers** by assigning them to specific
properties and monitoring their activities. Additionally, they have the
ability to view and manage **Tenants**, tenant details, ensuring smooth
operations across all their properties.

**<u>Main Page:</u>**

The main page shows the user in session and allows the user to navigate
the different functionalities of his/her dashboard. The user will have a
top navigation bar and a logout button to return to the main menu

<img src="./media/image4.png"
style="width:5.98611in;height:2.55556in" />

**<u>Functions:</u>**

### Owner function on Managers

**<u>VIEW LIST OF MANAGERS</u>**

<img src="./media/image5.png"
style="width:5.99306in;height:2.53472in" />

**<u>CREATE MANAGER:</u>**

By filling in the required field, the owner is able to enter a new
manager in the system

<img src="./media/image6.png"
style="width:4.09722in;height:2.67767in" />

If the owner creates a valid manager, the manager will be added as shown
below

<img src="./media/image7.png" style="width:5.99306in;height:2.0625in" />

If the model is not valid , error messages are created to indicate the
user what to do or what went wrong

<img src="./media/image8.png"
style="width:4.52778in;height:4.08234in" />

**<u>UPDATE MANAGER</u>**

<img src="./media/image9.png" style="width:5.25in;height:3.75694in" />

If the update succeeds, the element modified will be shown, else , some
validation errors will be displayed to the users for them to understand
what went wrong.

**<u>DELETE MANAGER:</u>**

The owner can remove a manager from the system

<img src="./media/image10.png"
style="width:6.22793in;height:3.67361in" />

**<u>GET MANAGER DETAILS</u>**

The owner can get all the details associated to a specific manager

<img src="./media/image11.png" style="width:5.99306in;height:3.625in" />

**<u>SEARCH MANAGER</u>**

The owner is able to search a manager by their name

### Owner function on Tenants

**<u>VIEW LIST OF TENANTS:</u>**

<img src="./media/image12.png"
style="width:5.99306in;height:2.54861in" />

**<u>CREATE TENANT:</u>**

By filling in the required field, the owner is able to enter a new
tenant in the system

<img src="./media/image13.png" style="width:5.99306in;height:4.75in" />

If the owner creates a valid tenant, the tenant will be added to the
system as shown below

<img src="./media/image14.png"
style="width:5.98611in;height:2.70139in" />

If the model is not valid , error messages are created to indicate the
user what to do or what went wrong

<img src="./media/image15.png" style="width:6in;height:4.36111in" />

**<u>UPDATE TENANT</u>**

<img src="./media/image16.png"
style="width:4.98611in;height:2.89583in" />If the update succeeds, the
element modified will be shown, else , some validation errors will be
displayed to the users for them to understand what went wrong.

**<u>DELETE TENANT:</u>**

The owner can remove a Tenant from the system

<img src="./media/image17.png" style="width:5.99306in;height:4.25in" />

**<u>GET TENANT DETAILS</u>**

The owner can get all the details associated to a specific tenants

<img src="./media/image18.png"
style="width:5.21528in;height:3.06944in" />

**<u>SEARCH TENANT</u>**

The owner is able to search a tenant by their name

<img src="./media/image19.png"
style="width:5.99306in;height:2.1875in" />

### 2.Manager

**<u>Description:</u>**

A **Manager** in the application acts as a link between the owner and
the tenants. They are responsible for handling buildings and apartments,
managing those property. Managers help keep the properties running
smoothly by staying in contact with the tenants through appointments and
messages while keeping both owners and tenants satisfied.

**<u>Main Page:</u>**

The main page shows the user in session and allows the user to navigate
the different functionalities of his/her dashboard. The user will have a
top navigation bar and a logout button to return to the main menu

<img src="./media/image20.png"
style="width:5.99306in;height:2.5625in" />

**<u>Functions:</u>**

### Manager functions on buildings

**<u>VIEW LIST OF BUILDINGS</u>**

<img src="./media/image21.png"
style="width:5.99306in;height:2.3125in" />

**<u>CREATE BUILDINGS:</u>**

By filling in the required field, the manager is able to enter a new
building in the system

<img src="./media/image22.png"
style="width:5.99306in;height:4.33333in" />

If the manager creates a valid buildings, the builing will be added as
shown below

<img src="./media/image23.png"
style="width:5.99306in;height:2.90972in" />

If the model is not valid , error messages are created to indicate the
user what to do or what went wrong

<img src="./media/image24.png"
style="width:5.99306in;height:2.70139in" />

**<u>UPDATE BUILDINGS</u>**

<img src="./media/image25.png"
style="width:5.99306in;height:2.72917in" />

If the update succeeds, the element modified will be shown else, some
validation errors will be displayed to the users for them to understand
what went wrong.

**<u>DELETE BUILDINGS:</u>**

The manager can remove a buildings from the system

<img src="./media/image26.png" style="width:5.99306in;height:4.125in" />

**<u>GET BUILDINGS DETAILS</u>**

The managers can get all the details associated to a specific building

<img src="./media/image27.png" style="width:6in;height:3.18056in" />

### b. Manager functions on apartments

**<u>VIEW LIST OF APARTMENTS</u>**

<img src="./media/image28.png"
style="width:5.99306in;height:2.60417in" />

**SEARCH APARTMENTS BY STATUS**

<img src="./media/image29.png"
style="width:5.98611in;height:2.46528in" />

After selecting the status and the button view, the list of the
apartments with the status selected will be shown in the example below
the user chose the “occupied ” status

<img src="./media/image30.png"
style="width:5.99306in;height:2.54861in" />

**<u>CREATE APARTMENTS:</u>**

By filling in the required field, the manager is able to enter a new
apartment in the system

<img src="./media/image31.png" style="width:6in;height:4.09722in" />

If the manager creates a valid apartment, the apartment will be added as
shown below

<img src="./media/image32.png"
style="width:5.99306in;height:2.90278in" />

If the model is not valid, error messages are created to indicate the
user what to do or what went wrong

<img src="./media/image33.png" style="width:6in;height:5.31944in" />

**<u>UPDATE APARTMENTS</u>**

<img src="./media/image34.png"
style="width:5.99306in;height:4.28472in" />

If the update succeeds, the element modified will be shown else, some
validation errors will be displayed to the users for them to understand
what went wrong.

**<u>DELETE APARTMENTS:</u>**

The manager can remove apartments from the system

<img src="./media/image35.png"
style="width:5.99306in;height:5.29167in" />

**<u>GET APARTMENTS DETAILS</u>**

The managers can get all the details associated to a specific building

<img src="./media/image36.png"
style="width:5.38194in;height:5.50694in" />

### c. Manager functions on appointments

**<u>MANAGE APPOINTMENTS:</u>**

The manager can reject or accept any received appointment request from
the tenant

<img src="./media/image37.png"
style="width:5.72222in;height:2.82639in" />

VIEW APPARTMENT AND SEARCH

The manager can view all his appointment and search for them by id

<img src="./media/image38.png" style="width:6in;height:2.36806in" />

**<u>GENERATE SCHEDULE</u>**

The system allows the manager to generate schedule for the tenant to
request appointment

<img src="./media/image39.png"
style="width:5.99306in;height:2.71528in" />

### d. Manager functions on Messages

**<u>VIEW INBOX</u>**

The manager can view his message inbox <img src="./media/image40.png"
style="width:5.99306in;height:2.45139in" />

**<u>REPLY TO MESSAGE</u>**

The manager can reply to the received messages

<img src="./media/image41.png"
style="width:5.98611in;height:3.03472in" />

**<u>DELETE MESSAGE</u>**

The manager can delete messages

<img src="./media/image42.png" style="width:6in;height:5.03472in" />

**<u>VIEW SENTBOX</u>**

The manager can view the message sent

<img src="./media/image43.png"
style="width:5.98611in;height:3.00694in" />

### 3. Tenants

**<u>Description</u>**

A **Tenant** in the application is a client who rents a property. They
can view property details, make appointments and communicate with the
manager. The application provides tenants with a convenient way to
manage their rental experience.

**<u>Main Page :</u>**

The main page shows the user in session and allows the user to navigate
the different functionalities of his/her dashboard. The user will have a
top navigation bar and a logout button to return to the main menu

<img src="./media/image44.png"
style="width:5.98611in;height:2.57639in" />

**<u>Functions:</u>**

### Tenant functions on apartments

**<u>VIEW LIST OF APARTMENTS</u>**

<img src="./media/image45.png"
style="width:5.99306in;height:2.58333in" />

**<u>SORT APPARTMENT BY ROOM AND PRICE</u>**

<img src="./media/image46.png"
style="width:5.98611in;height:2.56944in" />

**<u>VIEW THE DETAILS OF SPECIFIC APARTMENTS</u>**

<img src="./media/image47.png"
style="width:6.00694in;height:2.79861in" />

### Tenant functions on appointments

**<u>VIEW APPOINTMENTS REQUEST STATUS</u>**

<img src="./media/image48.png"
style="width:5.98611in;height:2.53472in" />

**<u>BOOK APPPOINTMENTS WITH A MANAGER</u>**

<img src="./media/image49.png"
style="width:5.99306in;height:2.64583in" />

### Tenant functions on Messages

**<u>VIEW INBOX</u>**

<img src="./media/image50.png"
style="width:5.99306in;height:2.54861in" />

**<u>REPLY TO MESSAGES</u>**

<img src="./media/image51.png"
style="width:5.98611in;height:2.52083in" />

**<u>SEND MESSAGES TO THE SELECTED MANAGER</u>**
<img src="./media/image52.png" style="width:6in;height:2.59028in" />

Database relationship:

<img src="./media/image53.png"
style="width:5.99306in;height:3.42361in" />
