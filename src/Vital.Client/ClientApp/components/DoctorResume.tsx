import * as React from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router';
import { ApplicationState }  from '../store';
import * as DoctorResumeState from '../store/Doctor';
import { Translate } from 'react-redux-i18n';
import * as LocaleState from '../store/Locale';


// At runtime, Redux will merge together...
type DoctorResumeProps =
    DoctorResumeState.DoctorState // ... state we've requested from the Redux store
    & LocaleState.LocaleState
    & typeof DoctorResumeState.actionCreators // ... plus action creators we've requested
    & { params: { idDoctor: string } }; // ... plus incoming routing parameters
 

class DoctorResume extends React.Component<DoctorResumeProps, void> {
    componentWillMount() {
        //El idDoctor lo deberiamos cogher del token del usuario logeado.
        // This method runs when the component is first added to the page
        let idDoctor = parseInt(this.props.params.idDoctor) || 0;
        this.props.requestDoctorResume(idDoctor);
    }

    //componentWillReceiveProps(nextProps: DoctorResumeProps) {
    //    // This method runs when incoming props (e.g., route params) change
    //    let idDoctor = parseInt(nextProps.params.idDoctor) || 0;
    //    this.props.requestDoctorResume(idDoctor);
    //}

    public render() {
        return <div>
            <div className="row border-bottom white-bg dashboard-header">
                <div className="ibox-content ibox-heading col-md-6">
                    <h3>Informacion Fiscal</h3>
                    <table className='table table-striped'>
                    <thead>
                    <tr>
                        <th>Periodo de retencion</th>
                        <th>Certificado</th>
                    </tr>
                    </thead>
                    <tbody>
                        {this.props.doctorResume.map(doctorResume => doctorResume.doctorTaxInformation.map(
                            doctorTaxInformation =>
                            <div >
                                <tr key={doctorTaxInformation.id}>
                                    <td>{doctorTaxInformation.year}</td>
                                    <td><Link to={doctorTaxInformation.certificate} activeClassName='active'>
                                        <span className='glyphicon glyphicon-file'></span> Descargar
                                    </Link></td>
                                </tr>
                            </div>
                        ))}
                        </tbody>
                    </table>
                </div>

            </div>
            
            <div className="row border-bottom white-bg dashboard-header">

                <div className="ibox-content ibox-heading">

                    <h3><Translate value="doctor.title" /></h3>
                    <small><i className="fa fa-file-pdf-o"></i> Haga click en los iconos de documento para descargar.</small>
                </div>
                { this.renderDoctorResumeTable() }
            </div>
        </div>;
    }
    
    private renderDoctorResumeTable() {
        return <div className='table-responsive'>
                   <table className='table table-striped'>
                       <thead>
                       <tr>
                           <th>Periodo de liquidacion</th>
                           <th>Observaciones</th>

                           <th>Recibo</th>
                           <th>Detalle de Servicios</th>
                           <th>Asegurados</th>
                           <th>Altas / Bajas</th>
                       </tr>
                       </thead>
                       <tbody>

                       {this.props.doctorResume.map((doctorResume) =>
                           <div>
                               <tr key={doctorResume.observations}>
                                   <td rowSpan={doctorResume.resume.length}>{doctorResume.month +
                                       "-" +
                                       doctorResume.year}</td>
                                   <td rowSpan={doctorResume.resume.length}><Link to={'http://www.google.es'
} activeClassName='active'>
                                           <span className="fa fa-file-pdf-o"></span> Descargar
                                       </Link>
                                   </td>
                                   <td><Link to={doctorResume.resume[0].receipt} activeClassName='active'>
                                       <span className="fa fa-file-pdf-o"></span> Ver liquidacion: {doctorResume
                                           .idDoctor +
                                           "-" +
                                           0}
                                   </Link></td>
                                   <td><Link to={doctorResume.resume[0].serviceDetails} activeClassName='active'>
                                       <span className="fa fa-file-pdf-o"></span> Ver liquidacion: {doctorResume
                                           .idDoctor +
                                           "-" +
                                           0}
                                   </Link><br/><Link to={doctorResume.resume[0].serviceDetails
} activeClassName='active'>
                                       <span className="fa fa-file-excel-o"></span> Ver liquidacion: {doctorResume
                                           .idDoctor +
                                           "-" +
                                           0}
                                   </Link></td>
                                   <td><Link to={doctorResume.resume[0].insureds} activeClassName='active'>
                                       <span className="fa fa-file-pdf-o"></span> Ver liquidacion: {doctorResume
                                           .idDoctor +
                                           "-" +
                                           0}
                                   </Link></td>
                                   <td><Link to={doctorResume.resume[0].registersUnregisters} activeClassName='active'>
                                       <span className="fa fa-file-pdf-o"></span> Ver liquidacion: {doctorResume
                                           .idDoctor +
                                           "-" +
                                           0}
                                   </Link></td>

                               </tr>
                               {doctorResume.resume.map((resume, index) => {

                                   if (index > 0) {
                                       return <tr>
                                                  <td><Link to={ resume.receipt } activeClassName='active'>
                                                      <span className="fa fa-file-pdf-o"></span> Ver liquidacion: {
                                                          doctorResume.idDoctor + "-" + index}
                                                  </Link></td>
                                                  <td><Link to={resume.serviceDetails} activeClassName='active'>
                                                      <span className="fa fa-file-pdf-o"></span> Ver liquidacion: {
                                                          doctorResume.idDoctor + "-" + index}
                                                  </Link><br/><Link to={resume.serviceDetails
} activeClassName='active'>
                                                      <span className="fa fa-file-excel-o"></span> Ver liquidacion: {
                                                          doctorResume.idDoctor + "-" + index}
                                                  </Link></td>
                                                  <td><Link to={resume.insureds} activeClassName='active'>
                                                      <span className="fa fa-file-pdf-o"></span> Ver liquidacion: {
                                                          doctorResume.idDoctor + "-" + index}
                                                  </Link></td>
                                                  <td><Link to={resume.registersUnregisters} activeClassName='active'>
                                                      <span className="fa fa-file-pdf-o"></span> Ver liquidacion: {
                                                          doctorResume.idDoctor + "-" + index}
                                                  </Link></td>
                                              </tr>;
                                   }
                                   return null;
                               })}

                           </div>
                       )}
                       </tbody>
                   </table>
               </div>;
    }
}


export default connect(
    (state: ApplicationState) => {return {

        locale: state.locale.locale,
        doctorResume: state.doctor.doctorResume,
        idDoctor: state.doctor.idDoctor,
        isLoading:  state.doctor.isLoading,
    }}, // Selects which state properties are merged into the component's props
    DoctorResumeState.actionCreators // Selects which action creators are merged into the component's props  
)(DoctorResume);    


    
