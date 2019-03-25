import { Component, Inject, OnInit } from '@angular/core';
import { Car } from '../models/car.model';
import { VehicleService } from '../vehicle-service.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CarBodyType } from '../models/carbodytype.model';
import { VehicleType } from '../models/vehicletype.model';
import { ActivatedRoute } from '@angular/router';
import { Boat } from '../models/boat.model';
import { Bike } from '../models/bike.model';

@Component({
  selector: 'add-vehicle',
  templateUrl: './add-vehicle.component.html',
  styleUrls: ['./add-vehicle.component.css']
})
export class AddVehicleComponent implements OnInit {
  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {   
      console.log(params);
      switch (params['type']) {
        case 'car':
          this.selectedVehicleType = VehicleType.Car;
          break;
        case 'bike':
          this.selectedVehicleType = VehicleType.Bike;
          break;
        case 'boat':
          this.selectedVehicleType = VehicleType.Boat;
          break;
        default:
          this.selectedVehicleType = VehicleType.Car;
          break;
      }
    });
  }
  carBodyTypes = Object.values(CarBodyType);
  vehicleTypes = Object.values(VehicleType);
  vehicleForm: FormGroup;
  carForm: FormGroup;
  bikeForm: FormGroup;
  boatForm: FormGroup;
  formSubmitted = false;
  formSuccess = false;
  selectedVehicleType = VehicleType.Car;
  constructor(private route: ActivatedRoute, private vehicleService: VehicleService, private router: Router, private formBuilder: FormBuilder) {
    this.vehicleForm = this.formBuilder.group({
      vehicleType: [VehicleType.Car, Validators.required],
      make: ['', Validators.required],
      model: ['', Validators.required],
    })
    this.carForm = this.formBuilder.group({
      engine: ['', Validators.required],
      doors: [0, Validators.required],
      wheels: [0, Validators.required],
      carBodyType: [CarBodyType.Sedan, Validators.required],
    })
    this.boatForm = this.formBuilder.group({
      carryingCapacity: [500, Validators.required],
    })
    this.bikeForm = this.formBuilder.group({
      learnerApproved: [true, Validators.required],
    })
  }
  vehicleTypeChanged(vehicleType: VehicleType) {
    console.log(vehicleType);
    this.selectedVehicleType = vehicleType;
  }
  onSubmit() {
    this.formSuccess = false;
    this.formSubmitted = true;
    if (!this.vehicleForm.invalid) {
      switch (this.selectedVehicleType) {
        case VehicleType.Car:
          if (!this.carForm.invalid)
            this.addCar();
          break;
        case VehicleType.Boat:
          if (!this.boatForm.invalid)
            this.addBoat();
          break;
        case VehicleType.Bike:
          if (!this.bikeForm.invalid)
            this.addBike();
          break;
      }

    }
  }
  isCarSelected() {
    return this.selectedVehicleType === VehicleType.Car;
  }
  isBikeSelected() {
    return this.selectedVehicleType === VehicleType.Bike;
  }
  isBoatSelected() {
    return this.selectedVehicleType === VehicleType.Boat;
  }
  addCar() {
    var car = new Car();
    car.Model = this.vehicleForm.controls.model.value;
    car.Make = this.vehicleForm.controls.make.value;
    car.Engine = this.carForm.controls.engine.value;
    car.Doors = this.carForm.controls.doors.value;
    car.Wheels = this.carForm.controls.wheels.value;
    car.BodyType = this.carForm.controls.carBodyType.value;
    this.vehicleService.createCar(car).subscribe(result => {
      this.router.navigateByUrl('/');
    }, error => {
      console.error(error);
    });
  }
  addBoat() {
    var boat = new Boat();
    boat.Model = this.vehicleForm.controls.model.value;
    boat.Make = this.vehicleForm.controls.make.value;
    boat.CarryingCapacity = this.boatForm.controls.carryingCapacity.value;
    this.vehicleService.createBoat(boat).subscribe(result => {
      this.router.navigateByUrl('/');
    }, error => {
      console.error(error);
    });
  }
  addBike() {
    var bike = new Bike();
    bike.Model = this.vehicleForm.controls.model.value;
    bike.Make = this.vehicleForm.controls.make.value;
    bike.LearnerApproved = this.bikeForm.controls.learnerApproved.value;
    this.vehicleService.createBike(bike).subscribe(result => {
      this.router.navigateByUrl('/');
    }, error => {
      console.error(error);
    });
  }
}
