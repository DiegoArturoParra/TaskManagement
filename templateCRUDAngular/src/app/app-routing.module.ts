import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarDataComponent } from './CRUD/listar/ListarData/ListarData.component';
import { CreateUpdateComponent } from './CRUD/Formulario/CreateUpdate/CreateUpdate.component';

const routes: Routes = [
  { path: 'sucursales', component: ListarDataComponent },
  { path: 'sucursales/crear', component: CreateUpdateComponent },
  { path: 'sucursales/actualizar/:BranchOfficeId', component: CreateUpdateComponent },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
