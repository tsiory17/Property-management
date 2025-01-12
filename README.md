# Manage Property Web Application 🏠

## Table of Contents
- [Technology](#technology-)
- [Introduction](#introduction-)
- [Preview](#preview-)
- [Different types of Roles](#different-types-of-roles-)
  - [1. Owner](#1-owner)
    - [Description](#description-1)
    - [Main Page](#main-page)
    - [Owner Functions on Managers](#owner-functions-on-managers)
      - [View List of Managers](#view-list-of-managers)
      - [Create Manager](#create-manager)
      - [Update Manager](#update-manager)
      - [Delete Manager](#delete-manager)
      - [Get Manager Details](#get-manager-details)
      - [Search Manager](#search-manager)
    - [Owner Functions on Tenants](#owner-functions-on-tenants)
      - [View List of Tenants](#view-list-of-tenants)
      - [Create Tenant](#create-tenant)
      - [Update Tenant](#update-tenant)
      - [Delete Tenant](#delete-tenant)
      - [Get Tenant Details](#get-tenant-details)
      - [Search Tenant](#search-tenant)
  - [2. Manager](#2-manager)
    - [Description](#description-2)
    - [Main Page](#main-page-1)
    - [Manager Functions on Buildings](#manager-functions-on-buildings)
      - [View List of Buildings](#view-list-of-buildings)
      - [Create Buildings](#create-buildings)
      - [Update Buildings](#update-buildings)
      - [Delete Buildings](#delete-buildings)
      - [Get Buildings Details](#get-buildings-details)
    - [Manager Functions on Apartments](#manager-functions-on-apartments)
      - [View List of Apartments](#view-list-of-apartments)
      - [Search Apartments by Status](#search-apartments-by-status)
      - [Create Apartments](#create-apartments)
      - [Update Apartments](#update-apartments)
      - [Delete Apartments](#delete-apartments)
      - [Get Apartments Details](#get-apartments-details)
    - [Manager Functions on Appointments](#manager-functions-on-appointments)
      - [Manage Appointments](#manage-appointments)
      - [View Appointment and Search](#view-appointment-and-search)
      - [Generate Schedule](#generate-schedule)
    - [Manager Functions on Messages](#manager-functions-on-messages)
      - [View Inbox](#view-inbox)
      - [Reply to Message](#reply-to-message)
      - [Delete Message](#delete-message)
      - [View Sentbox](#view-sentbox)
  - [3. Tenants](#3-tenants)
    - [Description](#description-3)
    - [Main Page](#main-page-2)
    - [Tenant Functions on Apartments](#tenant-functions-on-apartments)
      - [View List of Apartments](#view-list-of-apartments-1)
      - [Sort Apartment by Room and Price](#sort-apartment-by-room-and-price)
      - [View the Details of Specific Apartments](#view-the-details-of-specific-apartments)
    - [Tenant Functions on Appointments](#tenant-functions-on-appointments)
      - [View Appointments Request Status](#view-appointments-request-status)
      - [Book Appointments with a Manager](#book-appointments-with-a-manager)
    - [Tenant Functions on Messages](#tenant-functions-on-messages)
      - [View Inbox](#view-inbox-1)
      - [Reply to Messages](#reply-to-messages)
      - [Send Messages to the Selected Manager](#send-messages-to-the-selected-manager)
- [Database Relationship](#database-relationship)


      

## Technology 💻
The application is built using a combination of the following technologies:
- **C#**
- **ASP.NET Core MVC**
- **MS SQL**
- **Visual Studio**
- **HTML**
- **CSS**
- **JavaScript**

## Introduction 🏢
**Property Management Application** is a simple and effective platform that helps property owners, managers, and clients work together easily. It brings all the key features they need into one place, making property management smooth and convenient.

## Preview 👀
The application opens up on a page which states the mission of the website:

![Mission Page](./media/image1.png)

Once the user clicks the button "Get Started," it will redirect them to the login page:

![Login Page](./media/image2.png)

The login page allows the user to choose their role. The dashboard and functionalities will differ depending on their specific roles:

![Role Selection](./media/image3.png)

## Different types of Roles 🚀

## 1. Owner

#### Description
An **Owner** in the application is responsible for overseeing their properties. They can manage **Managers** by assigning them to specific properties and monitoring their activities. Additionally, they have the ability to view and manage **Tenants**, ensuring smooth operations across all their properties.

#### Main Page
The main page shows the user in session and allows them to navigate the different functionalities of their dashboard. The user will have a top navigation bar and a logout button to return to the main menu:

![Owner Main Page](./media/image4.png)

#### Owner Functions on Managers

##### View List of Managers
![View List of Managers](./media/image5.png)

##### Create Manager
By filling in the required fields, the owner can enter a new manager in the system:

![Create Manager](./media/image6.png)

If the owner creates a valid manager, the manager will be added as shown below:

![Manager Added](./media/image7.png)

If the model is not valid, error messages are displayed to indicate what went wrong:

![Manager Error](./media/image8.png)

##### Update Manager
![Update Manager](./media/image9.png)

If the update succeeds, the modified element will be shown. Otherwise, validation errors will be displayed for users to understand what went wrong.

##### Delete Manager
The owner can remove a manager from the system:

![Delete Manager](./media/image10.png)

##### Get Manager Details
The owner can get all the details associated with a specific manager:

![Manager Details](./media/image11.png)

##### Search Manager
The owner can search for a manager by their name.

#### Owner Functions on Tenants

##### View List of Tenants
![View List of Tenants](./media/image12.png)

##### Create Tenant
By filling in the required fields, the owner can enter a new tenant in the system:

![Create Tenant](./media/image13.png)

If the owner creates a valid tenant, the tenant will be added to the system as shown below:

![Tenant Added](./media/image14.png)

If the model is not valid, error messages are displayed to indicate what went wrong:

![Tenant Error](./media/image15.png)

##### Update Tenant
![Update Tenant](./media/image16.png)

If the update succeeds, the modified element will be shown. Otherwise, validation errors will be displayed for users to understand what went wrong.

##### Delete Tenant
The owner can remove a tenant from the system:

![Delete Tenant](./media/image17.png)

##### Get Tenant Details
The owner can get all the details associated with a specific tenant:

![Tenant Details](./media/image18.png)

##### Search Tenant
The owner can search for a tenant by their name:

![Search Tenant](./media/image19.png)

## 2. Manager

#### Description 

A **Manager** in the application acts as a link between the owner and the tenants. They are responsible for handling buildings and apartments, managing properties, and ensuring smooth operations. Managers maintain communication with tenants through appointments and messages, keeping both owners and tenants satisfied.

#### Main Page 

The main page shows the user in session and allows them to navigate the different functionalities of their dashboard. The user will have a top navigation bar and a logout button to return to the main menu:

![Manager Main Page](./media/image20.png)

#### Manager Functions on Buildings

##### View List of Buildings
![View List of Buildings](./media/image21.png)

##### Create Buildings
By filling in the required fields, the manager can enter a new building in the system:

![Create Buildings](./media/image22.png)

If the manager creates a valid building, it will be added as shown below:

![Building Added](./media/image23.png)

If the model is not valid, error messages are displayed to indicate what went wrong:

![Building Error](./media/image24.png)

##### Update Buildings
![Update Buildings](./media/image25.png)

If the update succeeds, the modified element will be shown. Otherwise, validation errors will be displayed for users to understand what went wrong.

##### Delete Buildings
The manager can remove a building from the system:

![Delete Buildings](./media/image26.png)

##### Get Buildings Details
The manager can get all the details associated with a specific building:

![Buildings Details](./media/image27.png)

#### Manager Functions on Apartments

##### View List of Apartments
![View List of Apartments](./media/image28.png)

##### Search Apartments by Status
![Search Apartments by Status](./media/image29.png)

After selecting the status and clicking the view button, the list of apartments with the selected status will be shown. In the example below, the user chose the "occupied" status:

![Occupied Apartments](./media/image30.png)

##### Create Apartments
By filling in the required fields, the manager can enter a new apartment in the system:

![Create Apartments](./media/image31.png)

If the manager creates a valid apartment, it will be added as shown below:

![Apartment Added](./media/image32.png)

If the model is not valid, error messages are displayed to indicate what went wrong:

![Apartment Error](./media/image33.png)

##### Update Apartments
![Update Apartments](./media/image34.png)

If the update succeeds, the modified element will be shown. Otherwise, validation errors will be displayed for users to understand what went wrong.

##### Delete Apartments
The manager can remove an apartment from the system:

![Delete Apartments](./media/image35.png)

##### Get Apartments Details
The manager can get all the details associated with a specific apartment:

![Apartments Details](./media/image36.png)

#### Manager Functions on Appointments

##### Manage Appointments
The manager can reject or accept any received appointment request from the tenant:

![Manage Appointments](./media/image37.png)

##### View Appointment and Search
The manager can view all their appointments and search for them by ID:

![View Appointment](./media/image38.png)

##### Generate Schedule
The system allows the manager to generate a schedule for tenants to request appointments:

![Generate Schedule](./media/image39.png)

#### Manager functions on Messages

#### View Inbox

The manager can view their message inbox.

![View Inbox](./media/image40.png)

#### Reply to message

The manager can reply to received messages.

![Reply to Message](./media/image41.png)

#### Delete Message

The manager can delete messages.

![Delete Message](./media/image42.png)

#### View Sentbox

The manager can view sent messages.

![View Sentbox](./media/image43.png)

## 3. Tenants

### Description

A **Tenant** in the application is a client who rents a property. They can view property details, make appointments, and communicate with the manager. The application provides tenants with a convenient way to manage their rental experience.

### Main Page

The main page shows the user in session and allows the user to navigate the different functionalities of their dashboard. The user will have a top navigation bar and a logout button to return to the main menu.

![Tenant Main Page](./media/image44.png)

### Functions:

### Tenant functions on apartments

#### View List of apartments

![View List of Apartments](./media/image45.png)

#### Sort Apartment by Room and Price

![Sort Apartment by Room and Price](./media/image46.png)

#### View the Details of Specific Apartments

![View the Details of Specific Apartments](./media/image47.png)

### Tenant functions on appointments

#### View Appointments Request Status

![View Appointments Request Status](./media/image48.png)

#### Book Appointments with a Manager

![Book Appointments with a Manager](./media/image49.png)

### Tenant functions on Messages

#### View Inbox

![View Inbox](./media/image50.png)

#### Reply to Messages

![Reply to Messages](./media/image51.png)

#### Send Messages to the Selected Manager

![Send Messages to the Selected Manager](./media/image52.png)

## Database relationship

![Database Relationship](./media/image53.png)
