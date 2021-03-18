# Medical Management Application

## About The Project

### Terms of Development

| Platform | GUI | Timeframe | Database Solution | Comunication Terms |
|----|----|----|----|----|
| Windows | WPF | 01.March.2021-09.May.2021 | Simple _.csv_ file storage | Notify client after each feature implementation

**Features**
- **Journals**
  - create journal - _The ability to raise new journals_
  - Save Journal - _The ability to save journals in the form of persistant data_
  - Update Journal - _The ability to update the data of exsisting journals_
  - Delete Journal - _The ability to delete existing journals_
  - Search for Journal - _The ability to search for a specific Journal based on a patients Social Security Number (SSN)_
  - Populate a Journal - _The ability to populate a Journal based on a Patients Social Security Number (SSN)_
  - To PDF - _If possible, within the given timeframe, the client would like to have a feature for printing a journal to PDF_
- **Patients**
  - Search for Patient - _The ability to look up a patient based on their Social Security Number (SSN)_
  - Readonly - _Can only be accessed, not created, updated, deleted or in any other way manipulated_

**Notes**
- Pregnancy Journal - _Will only be filled out once, when the journal is created_
- Traveling Journal - _Will be updated regularly_
- UI - _An agreement has been formed to have the UI be somehting that is regulated as we go, becaue there's no specifications regarding the layout of the UI._

## The program
**Goal**
> To form the least viable product (LVP)

**Input**
> User Interaction

**Output**
> Graphical User interface

## Code Practice
 - **Structs/Classes**
   - Form a `struct` if an `interface` category has four or more properties
   - Form a `class` if the above applies as well as if the object would consist of a larger structure
   - `Fields` are always private
   - `Properties` are always public
 - **Interfaces**
   - `Interfaces` are suffixed with 'I' and nothing else
   - `Interfaces` must have their own subfolder, which should never be included in their `namespace`
 - **Methods**
   - `Method` parameters are suffixed with an '_'
 - **Global**
   - `Scopes` must have explicit enclosure 
 - **ProjectStructure**
   - **Layers**
     - UI - All user integration (_API, GUI etc._)
     - Gateway - Connection to Business layer, databases, LAMP etc.
     - Business - All logic and direct behavior related to the core application

See the [Wiki](./WikiPages/Front.md) for more in depth information about the project.

## Versioning
The Assignment specifies that versioning should be done according to the following template: [_Major_].[_Minor_].[_Patch_].
- **Major:**
  - Major Changes
  - Changes to Core structure (_Like an UI Switch_)
- **Minor:**
  - Features
  - Large Code Refactoring (_Ex. If you create a new file when refactoring_)
- **Patch:**
  - Hotfixs
  - Revisions
  - Minor Code Refactoring

Each `Feature` must be branched out and developed on an isolated branch and merged back into the `Developer` branch when done.
The syntax for the structure of folders must be presented as: [DeveloperName]/[Version]/[BranchName], where as branches should be named as follows: [*Root*]-[*Feature*]_[*SubFeature*].\
**Example:**
>**Folder Structure:** _Oiski/v1_ \
>**Branch Name:** _MMA-Interface_MainMenu_ \
>**Full Path:** _Oiski/v1/MMA-Interface_MainMenu_

## Namespaces
Namespaces are bould from root and extended to branch out into different areas from there.
The core structure is as follows: [_Firm_].[_Project_].[_Folder_]. \
**Example**
>**Firm:** _NOP_ \
>**Project:** _MMA_ \
>**Folder:** _Repository_ \
>**Namespace:** _NOP.MMA.Repository_

### Change Log
- **[v...]()**
  - Implemented `Debug` class
  - Added WiKiFront
  - Added `Debug` class to WiKi