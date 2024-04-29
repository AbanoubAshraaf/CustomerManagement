# Customer Managment and Denomination routine
The Customer Management API Solution consists of three projects:

  - [CustomerManagemntAPI](#customermanagementapi)
  - [CustomerManagementAPISimulator](#customermanagementapisimulator)
  - [Denomination routine](#denomination-routine)

## Contents
  - [Installation](#installation)
  - [CustomerManagemntAPI](#customermanagementapi)
  - [CustomerManagementAPISimulator](#customermanagementapisimulator)
  - [Denomination routine](#denomination-routine)
  - [Program Structure](#program-structure)
    
### Installation
```bash
$ git clone https://github.com/AbanoubAshraaf/CustomerManagement.git
```
```bash
$ cd CustomerManagement
```
## CustomerManagementAPI
This project contains the main Customer Management API, which provides RESTful endpoints for managing customer records.

```bash
$ cd Abanoub.CM.API
```
```bash
$ dotnet run
```
## CustomerManagementAPISimulator
This project is a simulator for testing the Customer Management API. It allows you to send multiple requests to the API in parallel to simulate real-world usage.

```bash
$ cd Abanoub.CM.Simulator
```
```bash
$ dotnet run
```
## Denomination routine
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
