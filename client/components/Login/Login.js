import m from 'mithril';
import {LoginModalContent} from '../Modal/ModalContents'
import Modal from '../Modal/Modal'

window.isLoggedIn = false;

export default function Login() {
	function view() {
		return (	
			<Modal title = {"Log In"} size = {"lg"}>
				<LoginModalContent/>
			</Modal>
		);
	}
	return {view};
}