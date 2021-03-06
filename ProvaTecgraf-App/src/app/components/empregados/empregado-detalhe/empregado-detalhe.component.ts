import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { Empregado } from 'src/app/models/empregado';
import { EmpregadoService } from 'src/app/services/empregado.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-empregado-detalhe',
  templateUrl: './empregado-detalhe.component.html',
  styleUrls: ['./empregado-detalhe.component.css']
})
export class EmpregadoDetalheComponent implements OnInit {

  empregado = {} as Empregado;
  form!: FormGroup;
  estadoSalvar = 'post';

  constructor(
    private fb: FormBuilder,
    private localeService: BsLocaleService,
    private empregadoService: EmpregadoService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private router: Router,
  )  {
      this.localeService.use('pt-br');
     }

  ngOnInit() {
    this.validation();
  }

  public validation(): void {
    this.form = this.fb.group({
      firstName: [
        '',
        [
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(50),
        ],
      ],
      secondName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      dateOfBirth: ['', Validators.required],
      currentlyEmployed: ['', Validators.required],
    });
  }

  get modoEditar(): boolean{
    return this.estadoSalvar =='put';
  }

  public cssValidator(campoForm: FormControl | AbstractControl): any{
    return {'is-invalid': campoForm.errors && campoForm.touched };
  }

  get f(): any {
    return this.form.controls;
  }

  get bsConfigPropriedade(): any{
    return {
      adaptivePosition: true,
      dateInputFormat: 'DD-MM-YYYY HH:mm a',
      containerClass: 'theme-green',
      showWeekNumbers: false
    };
  }

  public  resetForm(): void{
    this.form.reset();
  }

  public salvarEmpregado(): void{
    this.spinner.show();
    if (this.form.valid){
      debugger;
      if(this.estadoSalvar == 'post'){
      // O "value" ter?? todos os valores do objeto evento, que atribuir?? ao this.evento. Como se fosse um automapper.
      this.empregado = {...this.form.value}
        this.empregadoService.postEmpregado(this.empregado).subscribe(
          (eventoRetorno: Empregado) => {
            this.toastr.success('Evento salvo com sucesso','Evento salvo!'),
            this.router.navigate([`eventos/detalhe/${eventoRetorno.id}`]);
          },
          (error: any) =>{
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Erro ao salvar o evento','Erro ao salvar.');
          },
          () => this.spinner.hide()
        );
      } else {
        debugger;
        // O "value" ter?? todos os valores do objeto evento, que atribuir?? ao this.evento. Como se fosse um automapper.
      this.empregado = {id: this.empregado.id, ...this.form.value}
        this.empregadoService.putEmpregado(this.empregado.id, this.empregado).subscribe(
          () => {
            this.toastr.success('Evento alterado com sucesso','Evento alterado!');
          },
          (error: any) =>{
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Erro ao salvar o evento','Erro ao salvar.');
          },
          () => this.spinner.hide()
        );
      }
    }
  }
}
