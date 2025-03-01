package at.sampas.personal_share.file;

import at.sampas.personal_share.file.domain.FileStorage;
import at.sampas.personal_share.file.service.FileService;
import at.sampas.personal_share.file.service.UploadFileCommand;
import at.sampas.personal_share.shared.PermissionDeniedException;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.Mock;

import java.io.ByteArrayInputStream;

import static org.junit.jupiter.api.Assertions.assertThrows;

public class FileServiceTest {
    @Mock
    FileStorage mockedFileStorage;

    FileService fileService;
    UploadFileCommand uploadCommand;

    @BeforeEach
    public void setUp() {
        fileService = new FileService();
        uploadCommand = new UploadFileCommand("me", "testfile", "text/plain", new ByteArrayInputStream("content".getBytes()));
    }

    @Test
    public void test_onFileUpload_differentUserId_leadsToPermissionDeniedException() {


        assertThrows(PermissionDeniedException.class, () -> fileService.addFileForUser(command));
    }

    @Test
    public void test_onFileUpload_forUserThatIsNotFileOwner_leadsToPermissionDeniedException() {
        throw new UnsupportedOperationException();
    }

    @Test
    public void test_onFileUpload_publishesEvents() {
        throw new UnsupportedOperationException();
    }

    @Test
    public void test_onFileUpload_storesFile() {
        throw new UnsupportedOperationException();
    }

    @Test
    public void test_onFileUpload_savesModifiedFileOwner() {
        throw new UnsupportedOperationException();
    }


    /*

    uploadFile(UploadFileCommand command) {
        var user = currentUser(command.userId);                 // throws PermissionDeniedException
        var fileOwnerId = asFileOwner(user.getFileOwnerId());   // throws PermissionDeniedException

        var fileOwner = fileRepository.loadFileOwner(fileOwnerId);
        var storedFile = fileStorage.storeFile(command.name, command.type, command.content);

        fileOwner.addFile(storedFile);

        fileRepository.save(fileOwner);

        eventBus.publish(fileOwner.getEvents());
    }



     */
}
