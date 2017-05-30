import * as React from 'react';
import { Link } from 'react-router';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';
import * as DoctorResumeState from '../store/Doctor';

// At runtime, Redux will merge together...
type DoctorTaxInformationProps =
    DoctorResumeState.DoctorState // ... state we've requested from the Redux store
    & typeof DoctorResumeState.actionCreators // ... plus action creators we've requested
    & { params: { idDoctor: string } }; // ... plus incoming routing parameters
 

class DoctorTaxInformation extends React.Component<DoctorTaxInformationProps, void> {
    componentWillMount() {
        //El idDoctor lo deberiamos coger del token del usuario logeado.
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
                        <h3>Información Fiscal</h3>
                        <small><i className="fa fa-file-pdf-o"></i> Haga click en los iconos de documento para descargar.</small>
                   </div>             
                   { this.renderDoctorTaxInformationTable() }
               </div>;
    }
    
    private renderDoctorTaxInformationTable() {
        return <div >
            
               </div>;
    }
}

export default connect( 
    (state: ApplicationState) =>
    state.doctor, // Selects which state properties are merged into the component's props
    DoctorResumeState.actionCreators // Selects which action creators are merged into the component's props  
)(DoctorTaxInformation);



