# Industrial Zone Management System

A Windows desktop application developed in C# (WPF/.NET Framework) 
for managing industrial zones, land plots, investors, and lot 
attributions. Built during a school internship and successfully 
migrated to Visual Studio Community 2026.

## Screenshots

![Login](screenshots/screenshot-login.png)

<img width="555" height="947" alt="screenshot-login" src="https://github.com/user-attachments/assets/a8baf101-61b3-45c4-a409-2fbfa1938e9c" />


![Main](screenshots/screenshot-main.png)

<img width="1346" height="896" alt="screenshot-main" src="https://github.com/user-attachments/assets/d5519f18-93aa-4498-b436-2a51179f2971" />


![Form](screenshots/screenshot-form.png)

<img width="1345" height="893" alt="screenshot-form" src="https://github.com/user-attachments/assets/6b1af3ad-ed1d-45ad-8ecf-48af55a7e071" />


![Login](screenshots/screenshot-list.png)

<img width="1346" height="897" alt="screenshot-list" src="https://github.com/user-attachments/assets/efd4aad3-a488-4d10-8c54-de378e16d676" />


![Login](screenshots/screenshot-search.png)

<img width="1345" height="890" alt="screenshot-search" src="https://github.com/user-attachments/assets/3644949f-2697-453b-9e98-b41364ffe6d7" />


![Sort](screenshots/screenshot-sort.png)

<img width="1346" height="896" alt="screenshot-sort" src="https://github.com/user-attachments/assets/08d4d8fb-92e2-48d2-9a2b-b92425c9b5e7" />

## Database Schema

<img width="882" height="542" alt="Database_schem" src="https://github.com/user-attachments/assets/32c38b0f-be8e-4abd-be36-6bd056c0c496" />



## Design Decisions
The initial conceptual model placed attribution references 
inside the Lot table. During implementation this was refactored 
into a dedicated Attribution junction table with foreign keys 
to both Lot and Investisseur, correctly modeling the 
many-to-many relationship between lots and investors.
Zones and lots represent fixed physical infrastructure that 
rarely changes. Attribution is the transactional entity — 
recording which investor occupies which lot. This distinction 
drove the separation of static reference data (zones, lots) 
from dynamic transactional records (attributions).

## Tech Stack
- **Language:** C# with WPF and XAML
- **Database:** MySQL via WampServer/phpMyAdmin
- **Libraries:** MySql.Data, Material Design in XAML, FontAwesome.Sharp
- **IDE:** Visual Studio Community 2026 (.NET Framework 4.8)

## Database Structure
6 relational tables with foreign key relationships:
- **Zones** — industrial zones
- **Lots** — land plots belonging to zones
- **Investors** — investor profiles and company information
- **Attributions** — junction table linking investors to lots
- **Daïras / Communes** — geographic lookup tables for controlled entry
- **Users** — authentication

## Features
- Secure user login and authentication
- Full CRUD operations across all entities
- Search, sort, and filter records
- Input validation and user feedback messages
- Controlled data entry using lookup tables

## Architecture
Built using MVC pattern:
- **SQLHelper.cs** — centralized database connection and query 
  execution using MySql.Data
- **Controllers** — separate CRUD classes per entity
- **Views** — WPF/XAML interfaces calling controller methods, 
  keeping UI logic separate from business logic

## Known Limitations
- UI layout needs improvement — current design uses large buttons 
  and many input fields which affects usability
- Input validation could be more comprehensive

## What I Learned

**Database & Backend:**
- Connecting C# to MySQL using MySql.Data library and managing 
  connection lifecycle properly
- Embedding SQL queries directly in C# functions and passing 
  parameters safely to avoid errors
- Converting string inputs to correct date formats before 
  database insertion
- Setting correct database parameters — UTF-8 encoding, 
  appropriate data types per field
- Designing a relational database conceptually vs implementing 
  it in code are two different challenges

**Architecture & Code Quality:**
- MVC separation — controllers, views, and models each have 
  distinct responsibilities
- Reusable functions with parameters produce predictable, 
  testable behavior
- Try/catch blocks for exception handling — hiding technical 
  errors from users and showing friendly messages instead
- Declaring namespaces and using directives to access external 
  library objects
- Working with classes, objects, and object-oriented principles 
  to reduce code duplication

**Frontend & UI:**
- XAML is more precise and efficient than drag-and-drop UI design
- Using frames to display multiple interfaces within one window 
  without rebuilding the outer layout
- XAML can auto-generate C# event handler signatures for UI elements
- Frontend design is equally important as backend functionality
- Changing startup URI to display login screen before main window

**General:**
- Building a complete application forces you to think from the 
  user's perspective, prioritizing quality over speed
- The gap between knowing concepts and implementing them in a 
  real project is significant
