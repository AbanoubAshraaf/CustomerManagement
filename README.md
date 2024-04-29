# Customer Managment and Denomination routine
The Customer Management API Solution consists of three projects:

  - [CustomerManagemntAPI](#-Customer-Management-API)
  - [CustomerManagementAPISimulator](#-#-Customer-Management-API=Simulator)
  - [Denomination routine](#-Denomination-routine)

## Contents
  - [Installation](#-get-started)
  - [CustomerManagemntAPI](#-Customer-Management-API)
  - [CustomerManagementAPISimulator](#-#-Customer-Management-API=Simulator)
  - [Denomination routine](#-Denomination-routine)
  - [Program Structure](#-Program-Structure)
    
### Installation
```bash
$ https://github.com/AbanoubAshraaf/CustomerManagement.git
```

## CustomerManagementAPI:
This project contains the main Customer Management API, which provides RESTful endpoints for managing customer records.

```bash
$ cd Abanoub.CM.API
```
```bash
$ dotnet run
```
## CustomerManagementAPISimulator:
This project is a simulator for testing the Customer Management API. It allows you to send multiple requests to the API in parallel to simulate real-world usage.

```bash
$ cd Abanoub.CM.Simulator
```
```bash
$ dotnet run
```
## Denomination routine:
a program which will calculate for each payout the possible combinations from the three cartridges 10,50 and 100 which the ATM can pay out.

```bash
$ cd Abanoub.Denomination.Routine
```
```bash
$ dotnet run
```
## Program Structure
```ts
/**
 *   └── Solution
        │   ├── Abanoub.CM.API
        │   ├── Abanoub.CM.BLL
        │   ├── Abanoub.CM.BOL
        │   ├── Abanoub.CM.Core
        │   ├── Abanoub.CM.DAL
        │   ├── Abanoub.CM.Simulator
        │   └── Abanoub.Denomination.Routine
 * /
```
