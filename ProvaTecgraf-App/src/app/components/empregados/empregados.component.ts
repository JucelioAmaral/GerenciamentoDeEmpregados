import { Component, OnInit } from '@angular/core';
import { Empregado } from 'src/app/utils/empregado';
import { EmpregadoService} from 'src/app/services/empregado.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-empregados',
  templateUrl: './empregados.component.html',
  styleUrls: ['./empregados.component.css'],
})
export class EmpregadoComponent implements OnInit {

  public empregados: Empregado[] = [];
  public empregosFiltrados: Empregado[] = [];

  private filtroListado: string = '';

  constructor(private empregadoService: EmpregadoService,
              private spinner: NgxSpinnerService,
  ) {}

  ngOnInit(): void {
    this.spinner.show();
    this.getEmpregados();
  }

  public getEmpregados() : void {
    this.empregadoService.getEmpregados().subscribe((empregado: any) => {
      this.empregados = empregado;
      this.empregosFiltrados = this.empregados;
    });
  }

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {

    this.filtroListado = value;
    this.empregosFiltrados = this.filtroLista
      ? this.filtrarEmpregos(this.filtroLista)
      : this.empregados;
  }

  public filtrarEmpregos(filtrarPor: string): Empregado[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.empregados.filter(
      (empregado: any) =>
      empregado.firstName.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      empregado.secondName.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      empregado.email.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }
}
