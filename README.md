
# SignalR Restaurant Project

In this project, a comprehensive study was conducted using the .NET n-tier layered architecture, with a focus on real-time data retrieval operations through SignalR.








## Folder Structure

SignalR.BusinessLayer --> I separated it into two files: Abstract and Concrete. In the Abstract part, I kept signatures related to interfaces specific to entities, and in the Concrete part, I implemented the methods corresponding to these signatures. Here, all operations were carried out by communicating with the database.

SignalR.DataAccessLayer --> I created Abstract, Concrete, EntityFramework, and Repositories folders. In the Abstract folder, I ensured that all entities derive from the IGenericDal structure and provided the relevant signatures. In the Concrete folder, I implemented the processes for connecting to the database. In the EntityFramework folder, I implemented more detailed methods specific to entities. In the Repositories folder, I created a class named GenericRepositories to perform basic operations such as adding, removing, deleting, and updating all objects under the T Generic structure.

SignalR.DtoLayer --> Here, I wrote the necessary properties for adding, removing, updating, and deleting operations under the Dto folder for each entity.

SignalR.EntityLayer --> Here, I created the necessary entity objects.

SignalRApi --> Here, I opened the Controllers, Hubs, and Mapping folders. In the Controllers folder, I defined controllers and wrote services. I utilized SignalR technology in the Hubs class. In the Mapping folder, I performed the mappings between Entity and Dto.

SignalRWebUI --> Here, I integrated the necessary themes with wwroot. By defining controllers, I consumed the services in the SignalRApi layer. I defined the necessary DTOs for WebUI in the Dtos folder. I performed all the required view operations for the website with ViewComponents and Views.










  
## Project İmages

![photo1](https://github.com/hacik-ulu/SignalRProject/assets/116976072/97d5849e-a0fb-4cf2-8108-38de03dc6dbe)

![Photo2](https://github.com/hacik-ulu/SignalRProject/assets/116976072/2fbf4529-c9b8-42e2-89fd-0ec7db9fad43)

![p3](https://github.com/hacik-ulu/SignalRProject/assets/116976072/04f65362-4fdb-4cce-ac7b-83e33451b111)

![p4](https://github.com/hacik-ulu/SignalRProject/assets/116976072/043988a7-0cb3-439c-b892-86559ae59819)

![p5](https://github.com/hacik-ulu/SignalRProject/assets/116976072/b5639644-bd1b-42a8-8907-a1f6ca923832)

![p6](https://github.com/hacik-ulu/SignalRProject/assets/116976072/580e3c23-8948-49cc-9832-53b28299c868)

![p7](https://github.com/hacik-ulu/SignalRProject/assets/116976072/b9e3fccc-98ba-45a9-adf7-d238a4ff04d2)

![p8](https://github.com/hacik-ulu/SignalRProject/assets/116976072/919daa3f-474a-4a34-aa0f-ff8b58b10349)

![p9](https://github.com/hacik-ulu/SignalRProject/assets/116976072/0662dc6b-b8c3-430c-9961-c72017cf3b85)

![p10](https://github.com/hacik-ulu/SignalRProject/assets/116976072/a8073f2d-cbb6-435b-a314-839bf41638b9)

![p11](https://github.com/hacik-ulu/SignalRProject/assets/116976072/1b1cd731-b6a1-48c6-9f16-6d47dae277a0)

![stats](https://github.com/hacik-ulu/SignalRProject/assets/116976072/940f09c6-0d13-4ad5-9906-c5d8fac435bf)

![masalar](https://github.com/hacik-ulu/SignalRProject/assets/116976072/2b5d610e-dbb8-4c44-82f6-7ddb0c719842)

![mesaj](https://github.com/hacik-ulu/SignalRProject/assets/116976072/bf80939c-58bd-4859-9682-6feab11a55e2)

![anlık durum cubuk](https://github.com/hacik-ulu/SignalRProject/assets/116976072/16af3a57-b52f-4952-be08-521d7e087612)

![mailgönder](https://github.com/hacik-ulu/SignalRProject/assets/116976072/443ba824-066e-4dd4-94c4-30a66e1c6c23)

![QRKOD](https://github.com/hacik-ulu/SignalRProject/assets/116976072/4b517a0d-b8fb-4a4b-affc-7ce8b024aca6)
