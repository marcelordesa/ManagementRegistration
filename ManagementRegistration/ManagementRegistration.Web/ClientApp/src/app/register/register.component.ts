import { Component, Inject } from '@angular/core';
import { RegisterModel } from '../../../models/registermodel';
import { ProfessionModel } from '../../../models/professionmodel';
import { ProfessionsModel } from '../../../models/professionsmodel';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {
  public listProfission: ProfessionModel[];
  public register: RegisterModel;
  private _baseUrl: string;
  private _http: HttpClient;
  public nameRegister: string;
  public emailRegister: string;
  public dateBirthRegister: string;
  public professionIdRegister: string;
  public unemployedRegister: boolean;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute,
    private router: Router) {

    this._baseUrl = baseUrl;
    this._http = http;
    this.register = new RegisterModel();
  }

  ngOnInit() {
    this._http.get<ProfessionsModel>(this._baseUrl + 'api/Profession/GetAllProfession').subscribe(result => {
      if (result.error)
        alert(result.message);
      else
        this.listProfission = result.professions as ProfessionModel[];
    }, error => alert(error));
  }

  save() {
    if (this.validateFields()) {

      this.register.name = this.nameRegister;
      this.register.email = this.emailRegister;
      this.register.dateBirth = new Date(this.dateBirthRegister);
      this.register.professionId = Number(this.professionIdRegister);
      this.register.professionDescription = this.returnNemProfession(this.register.professionId);
      this.register.unemployed = this.unemployedRegister;

      this._http.post<RegisterModel>(this._baseUrl + 'api/Register/InsertRegister', this.register).subscribe(result => {

        if (result.error)
          alert(result.message);
        else
          this.router.navigate(['/listar']);

      }, error => alert(error));
    }
  }

  returnNemProfession(id) {
    for (let i = 0; i < this.listProfission.length; i++) {
      if (id === this.listProfission[i].professionId)
        return this.listProfission[i].description;
    }
    return "";
  }

  validateFields() {
    let message: string;
    message = "";
    if (this.nameRegister == "" || this.nameRegister == null)
      message = message + "Informe o nome!\n";

    if (this.emailRegister == "" || this.emailRegister == null)
      message = message + "Informe o e-mail!\n";

    if (this.professionIdRegister == "0" || this.professionIdRegister == null)
      message = message + "Escolha uma profissão!\n";

    if (this.dateBirthRegister == "" || this.dateBirthRegister == null)
      message = message + "Informe o data de nascimento!\n";

    if (message != "") {
      alert(message);
      return false;
    }

    return true;
  }
}
