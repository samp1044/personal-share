package at.sampas.personal_share.file;

import at.sampas.personal_share.file.domain.FileStorage;
import at.sampas.personal_share.file.service.FileService;
import at.sampas.personal_share.file.service.UploadFileCommand;
import at.sampas.personal_share.shared.PermissionDeniedException;
import at.sampas.personal_share.user.User;
import at.sampas.personal_share.user.UserService;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.Mock;
import org.mockito.Mockito;

import java.io.ByteArrayInputStream;

import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.mockito.ArgumentMatchers.any;

public class FileServiceTest {
    @Mock
    FileStorage mockedFileStorage;

    @Mock
    UserService mockedUserService;

    User mockedUser;

    FileService fileService;
    UploadFileCommand uploadCommand;

    @BeforeEach
    public void setUp() {
        mockedUser = Mockito.mock(User.class);
        Mockito.when(mockedUserService.getCurrentUser(any())).thenReturn(mockedUser);

        fileService = new FileService();
        uploadCommand = new UploadFileCommand("me", "testfile", "text/plain", new ByteArrayInputStream("content".getBytes()));
    }

    @Test
    public void test_onFileUpload_differentUserId_leadsToPermissionDeniedException() {
        Mockito.when(mockedUserService.getCurrentUser(any())).thenReturn(null);

        assertThrows(PermissionDeniedException.class, () -> fileService.addFileForUser(command));
    }

    @Test
    public void test_onFileUpload_forUserThatIsNotFileOwner_leadsToPermissionDeniedException() {
        Mockito.when(mockedUser.getFileOwnerId()).thenReturn(null);

        assertThrows(PermissionDeniedException.class, () -> fileService.addFileForUser(command));
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
