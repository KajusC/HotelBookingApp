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

To get data to the In-built database, seed data with this API call, or edit it from [Data Seed class](https://github.com/KajusC/HotelBookingApp/blob/master/HotelBookingApp.Server/Data/DBInitializer.cs)
![image](https://github.com/KajusC/HotelBookingApp/assets/42713684/fea63dad-323b-4c98-9043-677d92780fbf)

VITE console can show some signs of error, it might mean that bootstrap isnt installed with node package manager
```bash
npm install bootstrap@v5.3.3
```

Seeded UI: ![image](https://github.com/KajusC/HotelBookingApp/assets/42713684/93ab0a4b-b15b-4b34-8b7e-8c112715bf85)

Modal view of booking form: ![image](https://github.com/KajusC/HotelBookingApp/assets/42713684/c6d276c2-f256-47db-ab0b-b9b2d48de47f)

Customer profile (simulated): ![image](https://github.com/KajusC/HotelBookingApp/assets/42713684/8df98966-4849-49dd-b10d-fe6430870e6f)

feel free to check our other projects!

