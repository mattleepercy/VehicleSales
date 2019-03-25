import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../vehicle-service.service';
import { Vehicle } from '../models/vehicle.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'vehicle',
  templateUrl: './vehicle.component.html',
})
export class VehicleComponent implements OnInit {
  loadedVehicle: Vehicle;
  objectKeys = Object.keys;
  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      console.log(params);
      var id = params.get('id');
      console.log(id);
      this.vehicleService.getVehicle(id).subscribe(result => {
        console.log(result);
        this.loadedVehicle = result;
      }, error => {
        console.error(error);
      })
    });
  }
  constructor(private route: ActivatedRoute, private vehicleService: VehicleService) {
  }
}
