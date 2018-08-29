import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegistersModel } from '../../../models/registersmodel';
import { RegisterModel } from '../../../models/registermodel';

@Component({
  selector: 'app-list-register',
  templateUrl: './list-register.component.html'
})
export class ListRegisterComponent {
  public listRegister: RegisterModel[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<RegistersModel>(baseUrl + 'api/Register/GetAllRegister').subscribe(result => {

      if (result.error)
        alert(result.message);
      else
        this.listRegister = result.registers;
    }, error => alert(error));
  }
}
