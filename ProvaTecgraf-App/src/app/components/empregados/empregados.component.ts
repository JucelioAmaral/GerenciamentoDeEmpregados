import { Component, OnInit } from '@angular/core';
import { Empregado } from 'src/app/utils/empregado';
import { EmpregadoService} from 'src/app/services/empregado.service';

@Component({
  selector: 'app-empregados',
  templateUrl: './empregados.component.html',
  styleUrls: ['./empregados.component.css'],
})
export class EmpregadoComponent implements OnInit {
  empregados: Empregado[] = [];

  constructor(private empregadoService: EmpregadoService) {}

  ngOnInit(): void {
    this.getEmpregados();
  }

  public getEmpregados() : void {
    this.empregadoService.getEmpregados().subscribe((empregado: any) => {
      this.empregados = empregado;
    });
  }
}
