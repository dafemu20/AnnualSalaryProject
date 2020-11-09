import { Component, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { Employee } from '../app/model/employee';
import { EmployeeService } from '../app/services/employee.service';
import { Exceptions } from './enum/exceptions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'annual-salay';
  datos: Employee[];
  idEmployee: string;

  @ViewChild(MatTable, {static: true}) tabla: MatTable<Employee>;

  constructor(private employeeService: EmployeeService) { }

  columns: string[] = ['id', 'name', 'contractTypeName', 'roleId', 'roleName', 'roleDescription',
  'hourlySalary', 'monthlySalary', 'annualSalary'];

  search() {
    this.datos = [];
    if (this.idEmployee === null || this.idEmployee === undefined || this.idEmployee === '') {
      this.getAllEmployees();
    } else {
      this.getEmployeeById(this.idEmployee);
    }
  }

  getEmployeeById(idEmployee: string) {
    this.employeeService.getEmployeeById(idEmployee).subscribe(response => {
      this.datos.push(response);
      this.tabla.renderRows();
    }, error => {
      this.validateInformationEmptyEmployee(error);
    });
  }

  getAllEmployees() {
    this.employeeService.getAllEmployees().subscribe(respuesta => {
      this.datos = respuesta;
      this.tabla.renderRows();
    }, error => {
      this.validateInformationEmptyEmployee(error);
    });
  }


  private validateInformationEmptyEmployee(error: any) {
    if (error.error.includes(Exceptions.EMPLOYEE_EMPTY_EXCEPTION)) {
      alert('Dont have results');
    }
  }
}

