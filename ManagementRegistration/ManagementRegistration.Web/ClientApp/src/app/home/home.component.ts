import { Component, Inject } from '@angular/core';
import { RegistersModel } from '../../../models/registersmodel';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public countRegisters: number;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute,
    private router: Router) {
    http.get<RegistersModel>(baseUrl + 'api/Register/GetAllRegister').subscribe(result => {

      this.countRegisters = 0;

      if (result.error)
        alert(result.message);
      else
        this.countRegisters = result.registers.length;
    }, error => alert(error));
  }

  listRegisters() {
    this.router.navigate(['/listar']);
  }

  register() {
    this.router.navigate(['/cadastro']);
  }
}
