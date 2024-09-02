# Hotel booking website

A short description about the project and/or client.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

The things you need before installing the software.

* .NET 8
* Download node.js
  (provided code is for windows powershell)
```bash
# installs fnm (Fast Node Manager)
winget install Schniz.fnm

# download and install Node.js
fnm use --install-if-missing 20

# verifies the right Node.js version is in the environment
node -v # should print `v20.13.1`

# verifies the right NPM version is in the environment
npm -v # should print `10.5.2`
```

### Installation

A step by step guide that will tell you how to get the development environment up and running.

project clone 
```
$ https://github.com/KajusC/HotelBookingApp.git
```

## Usage

Program will run 2 consoles: API (for swagger UI), VITE

Website is being run on Postgres Database

To enable the database, you have two contexts to update:
```bash
EntityFrameworkCore\Update-database -Context HotelDataContext

EntityFrameworkCore\Update-database -Context UserDataContext
```

VITE console can show some signs of error, it might mean that bootstrap isnt installed with node package manager
```bash
npm install bootstrap@v5.3.3
```

Main page: ![image](https://github.com/user-attachments/assets/ce1ad5de-0143-420b-ac8a-b7269f8a4750)

After pressing search: ![image](https://github.com/user-attachments/assets/d0a8b919-ddee-410a-b470-50453860a7bd)

Filtering (only location filter works): ![image](https://github.com/user-attachments/assets/f8821df0-6fd9-4ecc-bdcb-36e41178d110)

Hotel info card: ![image](https://github.com/user-attachments/assets/7929b19f-cb86-45cd-bc4c-a8e8bcb71513)

Log in Form: ![image](https://github.com/user-attachments/assets/328c513d-bc01-43fd-9ae6-e439cf1dd2eb)

Register Form: ![image](https://github.com/user-attachments/assets/a39047e3-0cd6-4792-a713-cc8d7c786655)

Successfull log in: ![image](https://github.com/user-attachments/assets/9ced1f27-3e48-465b-8c9e-8ba1f5d77713)

Profile: ![image](https://github.com/user-attachments/assets/0341866b-97ac-4661-90aa-c524733ddbf3)

Hotel addition form: ![image](https://github.com/user-attachments/assets/b37000c5-c87d-4ccb-b823-8483e779751c)

T.B.A.

feel free to check our other projects!

