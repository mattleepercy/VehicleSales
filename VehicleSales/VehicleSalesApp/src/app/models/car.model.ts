import { Vehicle } from "./vehicle.model";
import { CarBodyType } from './carbodytype.model';

export class Car extends Vehicle {
    Engine: string;
    Doors: number;
    Wheels: number;
    BodyType: CarBodyType;
}