import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuariosRoutingModule } from './usuarios-routing.module';

import { MaterialModule } from '../../shared/modules/material.module';
import { PipesModule } from '../../shared/modules/pipes.module';

import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { TableComponent } from './components/table/table.component';


@NgModule({
  declarations: [
    UsuariosComponent,
    TableComponent
  ],
  imports: [
    CommonModule,
    UsuariosRoutingModule,
    MaterialModule,
    PipesModule
  ]
})
export class UsuariosModule { }
