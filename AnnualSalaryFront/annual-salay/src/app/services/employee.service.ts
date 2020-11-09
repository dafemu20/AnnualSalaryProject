import { Injectable } from '@angular/core';
import { BaseService } from './base-service.service';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../model/employee';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService extends BaseService{

constructor(protected http: HttpClient) { super(http); }

getAllEmployees() {
  const endpoint = `https://localhost:5001/api/Employee/GetEmployees`;
  return this.doGet<Employee[]>(endpoint, this.optsName('get all employees'));
}

getEmployeeById(idEmployee: string) {
  const endpoint = `https://localhost:5001/api/Employee/GetEmployeeById/${idEmployee}`;
  return this.doGet<Employee>(endpoint, this.optsName('get all employees'));
}

}
