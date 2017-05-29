import * as React from 'react';
import { Link } from 'react-router';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';
import * as DoctorResumeState from '../store/Doctor';
import Resume = DoctorResumeState.Resume;

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
                           <th>mes</th>
                           <th>año</th>
                           <th>observaciones</th>

                           <th>insureds</th>
                           <th>receipt</th>
                           <th>reg/unreg</th>



                       </tr>
                       </thead>
                       <tbody>

                       {this.props.doctorResume.map(doctorResume => 
                        <div>
                               <tr key={doctorResume.observations}>
                                   <td rowSpan={doctorResume.resume.length}>{doctorResume.month}</td>
                                   <td rowSpan={doctorResume.resume.length}>{doctorResume.year}</td>
                                   <td rowSpan={doctorResume.resume.length}>{doctorResume.observations}</td>
                                   <td>{doctorResume.resume[0].insureds}</td>
                                   <td>{doctorResume.resume[0].receipt}</td>
                                   <td>{doctorResume.resume[0].registersUnregisters}</td>
                                   
                               </tr>
                            
                               {doctorResume.resume.map((resume, index) => {
                                 
                                    if (index  > 0) {
                                        <tr>
                                            <td>{resume.insureds}</td>
                                            <td>{resume.receipt}</td>
                                            <td>{resume.registersUnregisters}</td>
                                        </tr>;
                                    }
                                } )}
                               
                            </div>
                           )};
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



