import * as React from 'react';
import { Link } from 'react-router';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';
import * as DoctorResumeState from '../store/Doctor';

// At runtime, Redux will merge together...
type DoctorResumeProps =
    DoctorResumeState.DoctorState // ... state we've requested from the Redux store
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
        return <div className="row border-bottom white-bg dashboard-header">
            <div className="ibox-content ibox-heading">
                        <h3>Resumen ente medico</h3>
                        <small><i className="fa fa-file-pdf-o"></i> Haga click en los iconos de documento para descargar.</small>
                   </div>             
                   { this.renderDoctorResumeTable() }
               </div>;
    }
    
    private renderDoctorResumeTable() {
        return <div className='table-responsive'>
            <table className='table table-striped'>
                       <thead>
                       <tr>
                           <th>Periodo de liquidacion</th>
                           <th>Codigo de liquidacion</th>
                           <th>Recibo</th>       
                           <th>Detalle de servicios</th>   
                           <th>Observaciones</th>   
                           <th>Asegurados</th>   
                           <th>Altas / Bajas</th>  
                       </tr>
                       </thead>
                       <tbody>
                       {this.props.doctorResume.map(doctorResume =>
                        <tr key={doctorResume.observations}>
                            <td>{doctorResume.year}</td>
                            <td>{doctorResume.month}</td>
                            <td>{doctorResume.observations}</td>                            
                        </tr>
                       )}
                       </tbody>
                   </table>
               </div>;
    }
}

export default connect( 
    (state: ApplicationState) =>
    state.doctor, // Selects which state properties are merged into the component's props
    DoctorResumeState.actionCreators // Selects which action creators are merged into the component's props  
)(DoctorResume);



