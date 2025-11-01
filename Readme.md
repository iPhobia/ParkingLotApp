# 🅿️ Parking Lot Manager

## 🚀 How to Run

1. **Configure parking lot**  
   Enter the amount of parking lot spots for each type.

2. **Display parking lot state**  
   Type `showstate` to display the current state of the parking lot.

3. **Park a vehicle**  
   Type `park` to park your vehicle.  
   Then enter the vehicle type:
    - `car`
    - `motorcycle`
    - `van`

   Any other input will be treated as an **unknown vehicle**.

4. **Show occupied spots by vehicle type**  
   Type `showlot` to display how many spots are taken by a given vehicle type.  
   Then enter the vehicle type:
    - `car`
    - `motorcycle`
    - `van`

   Any other input will be treated as an **unknown vehicle**.

---

## ⚙️ Implementation Details

### 🧩 `ParkingLotManager`
- Performs **parking logic**.
- Provides information regarding:
    - The current **state** of the parking lot.
    - **Total occupied spots**.
    - **Spots taken per vehicle type**.

---

### 🧱 `ParkingLotSpot`
- Base class for different types of parking spots.
- Each spot type has a **predefined number of available spots**.
- Keeps track of:
    - Available spots
    - Taken spots
    - Parked vehicles
- Contains **business logic** to validate if a given vehicle can be parked in the chosen spot.

---

### 🚗 `Vehicle`
- Base class for different types of vehicles.
- Each vehicle type has a **preconfigured amount of required spots**.

---

### 🧠 Parking Rules & Assumptions

| Vehicle Type | Can Park In | Spots Taken |
|---------------|--------------|--------------|
| Motorcycle | Any spot | 1 |
| Car | Regular or Large spot | 1 |
| Van | Large spot | 3 (or equivalent of 3 regular spots) |

---

## ⚠️ Faced Issues & Assumptions

- **Missing data**: No information was given on how many spots each parking spot type should provide.  
  → Based on “A van can park in a large spot, but it will take up 3 regular spots”, it is assumed:
    - Motorcycle and regular spots each hold **1 spot**.
    - Large spot holds **3 spots**.

- **Vehicle spot usage**:  
  From the same rule, we assume:
    - `Motorcycle` and `Car` occupy **1 spot**.
    - `Van` occupies **3 spots**.

- **Van parking logic ambiguity**:  
  It’s not explicitly defined how van parking should behave.  
  Therefore, it’s assumed that **a parking spot can define how many spots it physically holds** (e.g. large = 3, regular = 1, motorcycle = 1).

- **`ParkedVehicles` design**:  
  `ParkingLotSpot.ParkedVehicles` is of type `List<T>`, which makes most sense for large spots.  
  However, changing it would **violate the Liskov Substitution Principle (LSP)**,  
  so keeping the same structure is considered acceptable.
