import { useNavigate } from 'react-router-dom';

const NavigationButton = (props:{ 
    path : string, 
    label : string }) => {
    
    const navigate = useNavigate();
    const handleClick = () => {
       navigate(props.path);
    };
   
    return (
        <button onClick={handleClick}>{props.label}</button>
    );
}

export default NavigationButton;