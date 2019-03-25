import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Vehicle } from './models/vehicle.model';
import { Car } from './models/car.model';
import { Boat } from './models/boat.model';
import { Bike } from './models/bike.model';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root',
})
export class VehicleService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  getVehicles() {
    return this.http.get<Vehicle[]>(this.baseUrl + 'api/vehicle', httpOptions);
  }

  getVehicle(id: string) {
    return this.http.get<Vehicle>(this.baseUrl + 'api/vehicle/' + id, httpOptions);
  }

  createVehicle(vehicle: Vehicle) {
    return this.http.post<Vehicle>(this.baseUrl + 'api/vehicle', vehicle, httpOptions);
  }
  
  createCar(car: Car) {
    return this.http.post<Car>(this.baseUrl + 'api/vehicle/car', car, httpOptions);
  }

  createBike(bike: Bike) {
    return this.http.post<Bike>(this.baseUrl + 'api/vehicle/bike', bike, httpOptions);
  }

  createBoat(boat: Boat) {
    return this.http.post<Boat>(this.baseUrl + 'api/vehicle/boat', boat, httpOptions);
  }
}
