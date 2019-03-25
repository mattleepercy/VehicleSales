import { Component, OnInit } from '@angular/core';
import { Vehicle } from '../models/vehicle.model';
import { VehicleType } from '../models/vehicletype.model';
import { VehicleService } from '../vehicle-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public vehicles: Vehicle[];
  VehicleType = VehicleType;
  constructor(private vehicleService : VehicleService, private router: Router) {
  }
  ngOnInit(){
    this.vehicleService.getVehicles().subscribe(result => {
      this.vehicles = result;
    }, error =>{
      console.error(error);
    });
  }
  openVehicleDetails(id: string) {
    console.log(id);
    this.router.navigateByUrl('/vehicle/'+id);
  }
}
