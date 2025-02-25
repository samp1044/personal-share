package at.sampas.personal_share.file;

import org.junit.jupiter.api.Test;

public class UploadFilesTest {
    @Test
    public void TestOwnerCanUploadANewFile() {
        // Upload file
        Owner owner = loadOwner(currentUser());
        UploadedFile fileUpload = fileStorage.UploadFile(name, type, contentStream);
        File file = owner.addFile(fileUpload);

        save(file);

        // Download file
        Visitor visitor = AsVisitor(currentUser());
        Grant grant = visitor.grantFor(key);

        Share share = loadShare(shareId);
        File file = share.getFile(fileId, grant);

        return fileStorage.stream(file);
    }
}
