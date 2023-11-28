import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarDataComponent } from './CRUD/listar/ListarData/ListarData.component';
import { CreateUpdateComponent } from './CRUD/Formulario/CreateUpdate/CreateUpdate.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { PerfilUserComponent } from './perfil-user/perfil-user.component';

const routes: Routes = [
  { path: 'gestion-tareas', component: ListarDataComponent },
  { path: 'gestion-tareas/crear', component: CreateUpdateComponent },
  { path: 'gestion-tareas/actualizar/:TaskId', component: CreateUpdateComponent },
  { path: 'registrarse', component: RegisterComponent },
  { path: 'perfil', component: PerfilUserComponent },
  { path: '', component: LoginComponent },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
